    using System;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var json = @"{""resultsList"":[{ ""id"":""1"",""last_event"":""Mar 20 07:08 AM"",""use_id"":""142AD"",""user_status"":""offline""}, { ""id"":""2"",
          ""last_event"":""Mar 19 08:07 AM"",
          ""use_id"":""1426BD"",
          ""user_status"":""offline""
        }
      ]
    }";
                var results = JsonConvert.DeserializeObject<Rootobject>(json);
                for (int i = 0; i < results.resultsList.Length; i++)
                {
                    Console.WriteLine("Id:" + results.resultsList[i].id);
                    Console.WriteLine("Last Event:" + results.resultsList[i].last_event);
                    Console.WriteLine("User ID:" + results.resultsList[i].use_id);
                    Console.WriteLine("User Status:" + results.resultsList[i].user_status);
                }
                Console.ReadKey();
            }
        }
        public class Rootobject
        {
            public Resultslist[] resultsList { get; set; }
        }
    
        public class Resultslist
        {
            public int id { get; set; }
            public string last_event { get; set; }
            public string use_id { get; set; }
            public string user_status { get; set; }
    
        }
    }
