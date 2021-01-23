     public class Program
     {
        public static void Main(string[] args)
        {
            UdpClient udpc = new UdpClient( System.Net.Dns.GetHostName(), 2055);
            IPEndPoint ep = null;
            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name == "") break;
                byte[] sdata = Encoding.ASCII.GetBytes(name);
                udpc.Send(sdata, sdata.Length);
                byte[] rdata = udpc.Receive(ref ep);
                string job = Encoding.ASCII.GetString(rdata);
                Console.WriteLine(job);
            }
        }
     }
