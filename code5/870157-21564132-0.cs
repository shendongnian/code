	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Security.Cryptography.X509Certificates;
	using System.Text;
	using System.Threading.Tasks;
	using SIPSorcery.Net;
	using SIPSorcery.SIP;
	using SIPSorcery.SIP.App;
	using SIPSorcery.Sys;
	namespace SIPTLS
	{
		class Program
		{
			static void Main(string[] args)
			{
				try
				{
					var sipTransport = new SIPTransport(SIPDNSManager.ResolveSIPService, new SIPTransactionEngine());
					sipTransport.SIPTransportRequestReceived += SIPRequestReceived;
					sipTransport.SIPTransportResponseReceived += SIPResponseReceived;
					X509Certificate2 cert = new X509Certificate2("test-cert.cer");
					SIPTLSChannel tlsChannel = new SIPTLSChannel(cert, new IPEndPoint(IPAddress.Any, 5061));
					sipTransport.AddSIPChannel(tlsChannel);
					var optionsReq = sipTransport.GetRequest(SIPMethodsEnum.OPTIONS, SIPURI.ParseSIPURI("sips:67.222.131.147:5061"));
					sipTransport.SendRequest(optionsReq);
				}
				catch(Exception excp)
				{
					Console.WriteLine("Exception Main. " + excp);
				}
				finally
				{
					Console.WriteLine("Press any key to exit...");
					Console.Read();
				}
			}
			private static void SIPRequestReceived(SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPRequest sipRequest)
			{
				Console.WriteLine("SIP request received from " + remoteEndPoint + ".");
				Console.WriteLine(sipRequest.ToString());
			}
			private static void SIPResponseReceived(SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPResponse sipResponse)
			{
				Console.WriteLine("SIP response received from " + remoteEndPoint + ".");
				Console.WriteLine(sipResponse.ToString());
			}
		}
	}
