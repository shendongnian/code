    using System;
    using System.Text;
    using System.Collections.Generic;
    using Thrift.Protocol;
    using Thrift.Transport;
    namespace AccumuloIntegratorPrototype
    {
	class MainClass
	{
		static byte[] GetBytes(string str)
		{
			return Encoding.ASCII.GetBytes(str);
		}
	
		static string GetString(byte[] bytes)
		{
			return Encoding.ASCII.GetString(bytes);
		}
	
		public static void Main (string[] args)
		{
		
			try
			{
				//Accumulo details
				String accumuloProxyServerIP = "192.168.1.44";//IP
				int accumuloProxyServerPort = 42424;//Port Number
				//Connect to Accumulo proxy server
				TTransport transport = new TSocket(accumuloProxyServerIP, accumuloProxyServerPort);
				transport = new TFramedTransport(transport);
				TCompactProtocol protocol = new TCompactProtocol(transport);
				transport.Open();
				String principal = "root";//Application ID
				Dictionary<string, string> passwd = new Dictionary<string,string>();
				passwd.Add("password", "xxxxx");//Password
				AccumuloProxy.Client client = new AccumuloProxy.Client(protocol);
				byte[] loginToken = client.login(principal, passwd);//Login token
				//{{
				//Read a range of rows from Accumulo
				var bScanner = new BatchScanOptions();
				Range range = new Range();
				range.Start = new Key();
				range.Start.Row = GetBytes("d001");
				//Need the \0 only if you need to get a single row back
				//Otherwise, its not needed
				range.Stop = new Key();
				range.Stop.Row = GetBytes("d001\0");
				bScanner.Ranges = new List<Range>();
				bScanner.Ranges.Add(range);
				String scanId = client.createBatchScanner(loginToken, "departments", bScanner);
				var more = true;
				while (more)
				{
					var scan = client.nextK(scanId, 10);
					more = scan.More;
					foreach (var entry in scan.Results)
					{
						Console.WriteLine("Row = " + GetString(entry.Key.Row));
						Console.WriteLine("{0} {1}:{2} [{3}]  {4}    {5}", GetString(entry.Key.Row), GetString(entry.Key.ColFamily), GetString(entry.Key.ColQualifier), GetString(entry.Key.ColVisibility), GetString(entry.Value),(long)entry.Key.Timestamp);
					}
				}
				client.closeScanner(scanId);
				client.Dispose();
				transport.Close();
				}catch (Exception e)
				{
					Console.WriteLine(e);
				}
			//}}
				
		}
	}
    }
