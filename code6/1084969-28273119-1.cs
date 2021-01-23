    using System;
    using System.Linq;
    using System.Net;
    using ARSoft.Tools.Net.Dns;
    namespace SOTestDNS
    {
      class Program
      {
        static void Main(string[] args)
        {
          var resp = DnsClient.Default.Resolve("google.com", RecordType.Ns);
          var nsrecords = resp.AnswerRecords.OfType<NsRecord>();
          foreach (var record in nsrecords)
          {
            Console.Write(record.NameServer);
            foreach (var address in Dns.GetHostAddresses(record.NameServer))
            {
              Console.WriteLine(" -> " + address);
            }
          }
        }
      }
    }
