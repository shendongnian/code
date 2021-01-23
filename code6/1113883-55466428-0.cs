using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Test
{
    public class Sentinel
    {
        private ConnectionMultiplexer Conn { get; }
        private IServer Server { get; }
        protected StringWriter ConnectionLog { get; }
        public Sentinel()
        {
            var options = new ConfigurationOptions()
            {
                CommandMap = CommandMap.Sentinel,
                EndPoints = { { "192.168.1.64", 26379 } },  //IP and Port of Sentinel
                AllowAdmin = true,
                TieBreaker = "",
                SyncTimeout = 5000
            };
            Conn = ConnectionMultiplexer.Connect(options, ConnectionLog);
            Server = Conn.GetServer("192.168.1.64", 26379); //IP and Port of Sentinel
        }
        public void SentinelGetMasterAddressByNameTest(string nameOfMaster)
        {
            var endpoint = Server.SentinelGetMasterAddressByName(nameOfMaster); 
            var ipEndPoint = endpoint as IPEndPoint;
            Console.WriteLine("The Master's <IP:Port>: {0}:{1}", ipEndPoint.Address, ipEndPoint.Port);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
           var sentinel = new Sentinel();
           sentinel.SentinelGetMasterAddressByNameTest("redis-test"); //Passing name of the master
           Console.ReadLine();
        }
    }
}
