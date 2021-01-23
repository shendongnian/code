    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Threading;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    
    
    namespace MyRTD
    {
         class Program
        {
         static void Main(string[] args)
            {
            //Based off of http://awkwardcoder.com/2014/01/24/excel-rtd-client-in-c/
            //and http://stackoverflow.com/questions/26726430/r6025-pure-virtual-function-call
           
                //var tosClassId = new Guid(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Tos.RTD\CLSID", "", null).ToString());
                var tosClassId=new Guid("{1B415BA9-E543-41BD-8EB1-CB12A5B7678F}");
                var rtdClient = new RtdClient(tosClassId);
    
                var date = DateTime.Now.Date;
             
                List<string> tos_sym = new List<string>();
                tos_sym.Add(".AAPL160819C106");
                tos_sym.Add(".AAPL160819C107");
                tos_sym.Add(".AAPL160819C108");
                tos_sym.Add(".AAPL160819C109");
    
                foreach (var optSym in tos_sym)
                  {
                    var optBid = GetDouble(rtdClient, optSym, "BID");
                    var optAsk = GetDouble(rtdClient, optSym, "ASK");
                    var optDelt = GetDouble(rtdClient, optSym, "DELTA");
    
                    Console.WriteLine(optSym + " BID: " + optBid + " ASK: " + optAsk + " DELTA: " + optDelt);
              
                    }
              }
    
                static double GetDouble(IRtdClient client, string symbol, string topic) {
                    object value;
                    if (client.GetValue2(TimeSpan.FromSeconds(3), out value, topic, symbol)) {
                        try { return double.Parse(value.ToString()); } catch { return 0; }
                    }
                    return 0;
                 }
    
            public interface IRtdClient
            {
               
                bool GetValue2(TimeSpan timeout, out object value, params object[] args);
            }
    
            public class RtdClient : IRtdClient
            {
    
                readonly Guid ServerId;
                static readonly Dictionary<Guid, IRtdServer> servers = new Dictionary<Guid, IRtdServer>();
                static readonly Dictionary<Guid, int> topicIds = new Dictionary<Guid, int>();
    
                public RtdClient(Guid serverId)
                {
                    ServerId = serverId;
                }
    
                public bool GetValue2(TimeSpan timeout, out object value, params object[] args)
                {
    
                    value = null;
                    var server = GetRtdServer();
                    var topicId = GetTopicId();
    
                    var sw = Stopwatch.StartNew();
                    var delay = 200;
    
                    try
                    {
                        server.ConnectData(topicId, args, true);
                        while (sw.Elapsed < timeout)
                        {
                            Thread.Sleep(delay);
                            delay *= 2;
                            var alive = server.Heartbeat();
                            if (alive != 1)
                            {
                                // TODO: What should be done here?
                                return false;
                            }
                            var refresh = server.RefreshData(1);
                            if (refresh.Length > 0)
                            {
                                if (refresh[0, 0].ToString() == topicId.ToString())
                                {
                                    value = refresh[1, 0];
                                    return true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: Log exception
                        return false;
                    }
                    finally
                    {
                        server.DisconnectData(topicId);
                        sw.Stop();
                    }
                    return false;
                }
    
    
                IRtdServer GetRtdServer()
                {
                    IRtdServer server;
                    if (!servers.TryGetValue(ServerId, out server))
                    {
                        Type rtd = Type.GetTypeFromCLSID(ServerId);
                        server = (IRtdServer)Activator.CreateInstance(rtd);
                        servers[ServerId] = server;
                    }
                    return server;
                }
    
                int GetTopicId()
                {
                    int topicId = 0;
                    if (topicIds.TryGetValue(ServerId, out topicId))
                    {
                        topicId++;
                    }
                    topicIds[ServerId] = topicId;
                    return topicId;
                }
            }
            [ComImport, TypeLibType((short)0x1040), Guid("EC0E6191-DB51-11D3-8F3E-00C04F3651B8")]
            public interface IRtdServer
            {
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(10)]
                int ServerStart([In, MarshalAs(UnmanagedType.Interface)] IRTDUpdateEvent callback);
    
                [return: MarshalAs(UnmanagedType.Struct)]
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
                object ConnectData([In] int topicId, [In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] ref object[] parameters, [In, Out] ref bool newValue);
    
                [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(12)]
                object[,] RefreshData([In, Out] ref int topicCount);
    
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(13)]
                void DisconnectData([In] int topicId);
    
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(14)]
                int Heartbeat();
    
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(15)]
                void ServerTerminate();
            }
    
            [ComImport, TypeLibType((short)0x1040), Guid("A43788C1-D91B-11D3-8F39-00C04F3651B8")]
            public interface IRTDUpdateEvent
            {
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(10), PreserveSig]
                void UpdateNotify();
    
                [DispId(11)]
                int HeartbeatInterval
                {
                    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
                    get;
                    [param: In]
                    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(11)]
                    set;
                }
    
                [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(12)]
                void Disconnect();
    
            }
    
    
        }
    }
