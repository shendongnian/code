    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace IPAddressTesting
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string[] tabtempsoctets1 = { "127", "1", "1", "1" };
			Ping pingeage = new Ping();
			//Ping pingeage = new Ping();
			String ip = tabtempsoctets1[0]
				+ "." + tabtempsoctets1[1]
				+ "." + tabtempsoctets1[2]
				+ "." + tabtempsoctets1[3];
			Console.WriteLine(ip);
			IPAddress adresseTest = IPAddress.Parse(ip);
			Console.WriteLine(adresseTest.ToString());
			byte [] addressAsBytes = new byte[tabtempsoctets1.Length];
			for (int i = 0; i < tabtempsoctets1.Length; i++)
			{
				if (!byte.TryParse(tabtempsoctets1[i], out addressAsBytes[i]))
					Console.WriteLine(tabtempsoctets1[i] + " is not formated correctely");
			}
			IPAddress adresseTest2 = new IPAddress(addressAsBytes);
			Console.WriteLine(adresseTest2.ToString());
			PingReply reponse = pingeage.Send(adresseTest2, 2000);
			Console.WriteLine(reponse.Status.ToString());
			Console.ReadKey();
		}
	}
