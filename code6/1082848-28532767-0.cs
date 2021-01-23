    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace resample2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var startDate = DateTime.ParseExact("2014-03-15", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var daily = Enumerable.Range(0, 60)
                            .Select(x => KeyValue.Create(startDate.AddDays(x), 15.03))
                            .Concat(Enumerable.Range(120, 60)
                            .Select(x => KeyValue.Create(startDate.AddDays(x), 15.03)))
                            .ToSeries();
    
                var monthly = daily.ResampleEquivalence(x => x.ToString("yyyy-MM") , s => s.Mean());
    
                monthly.Print();
    
                var keys = Enumerable.Range(0, 360)
                          .Select(x => startDate.AddDays(x).Date)
                          .Where(x => x.Day == 1)
                          .Select(x=> x.ToString("yyyy-MM"));
    
    
                var monthly2 = daily.ResampleEquivalence(x => x.ToString("yyyy-MM"), s => s.Mean()).Realign(keys);
    
                
    
                monthly2.Print();
    
                Console.ReadKey();
            }
    
        }
    }
