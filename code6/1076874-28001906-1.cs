    using StackExchange.Redis;
    
    using System;
    
    using System.Collections.Generic;
    
    using System.Diagnostics;
    
    using System.Threading;
    
    using System.Threading.Tasks;
  
    namespace RedisLatency
    
    {
    
        class Program
    
        {
    
            private const string host = "myazurecache.redis.cache.windows.net";
    
            private const string password = "password";
     
            private static int sortedsetlength;
    
            private static int iterations;
   
            private static IDatabase _cache;
    
            static void Main(string[] args)
    
            {
    
                sortedsetlength = Int32.Parse(args[0]);
    
                iterations = Int32.Parse(args[1]);
    
                CreateMultiplexer(host,password);
    
                PopulateTestData();
    
                RunTestSync();
    
                RunTestAsync();
    
            }
        
            private static void CreateMultiplexer(string host, string password)
    
            {
    
                Console.WriteLine("Measuring sync vs async for sorted set length {0}, iteration {1}", sortedsetlength,iterations);
    
                ConfigurationOptions configoptions = new ConfigurationOptions();
    
                configoptions.EndPoints.Add(host);
    
                configoptions.Password = password;
    
                configoptions.Ssl = true;
    
                ConnectionMultiplexer connection =   ConnectionMultiplexer.Connect(configoptions);
    
                _cache = connection.GetDatabase();
            }
    
            private static void PopulateTestData()
    
            {
    
              for (int i = 0; i < sortedsetlength; i++)
    
                {
                    _cache.SortedSetAdd("testsorted", "user" + i, i);
                }
            }
    
            static void RunTestSync()
    
            {
    
                for (int warmup = 0; warmup < 100; warmup++)
    
                {
    
                    MeasureSync();
    
                }
    
                Stopwatch sw = Stopwatch.StartNew();
    
                for (int i = 0; i < iterations;i++ )
    
                {
                    MeasureSync();
                }
    
                sw.Stop();
    
                Console.WriteLine("{0} sync calls completed in average {1} ms", iterations, sw.Elapsed.TotalMilliseconds/iterations);
            }
    
            async static void RunTestAsync()
    
            {
    
                //warm up
    
                for (int warmup = 0; warmup < 100; warmup++)
                {
                    MeasureAsync().Wait();    
                }
                Stopwatch sw = Stopwatch.StartNew();
    
                for (int i = 0; i < iterations; i++)
    
                {
    
                    MeasureAsync().Wait();
    
                }
    
                sw.Stop();
    
                Console.WriteLine("{0} async calls completed in average {1} ms", iterations, sw.Elapsed.TotalMilliseconds/iterations);
    
            }
    
            static public void MeasureSync()
    
            {
    
                var result = _cache.SortedSetRangeByScore("testset", 1.0, sortedsetlength / 1.0);
    
            }
    
            async static public Task MeasureAsync()
            {
                var result = await _cache.SortedSetRangeByScoreAsync("testset", 1.0, sortedsetlength / 1.0);
            }
        }
    
    }
