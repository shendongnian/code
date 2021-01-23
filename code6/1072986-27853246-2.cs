    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class Program {
        public static void Main() {
            Tuple<DateTime,DateTime> range=Tuple.Create(new DateTime(2015,1,1),new DateTime(2015,1,30));
            Tuple<DateTime,DateTime>[] exclude=new[] {
                Tuple.Create(new DateTime(2015,1,5),new DateTime(2015,1,10)),
                Tuple.Create(new DateTime(2015,1,15),new DateTime(2015,1,20)),
                Tuple.Create(new DateTime(2015,1,22),new DateTime(2015,1,28))
            };
            foreach(Tuple<DateTime,DateTime> r in ExcludeIntervals(range,exclude)) {
                Console.WriteLine("{0} - {1}",r.Item1,r.Item2);
            }
        }
        public static IEnumerable<Tuple<DateTime,DateTime>> ExcludeIntervals(Tuple<DateTime,DateTime> range,IEnumerable<Tuple<DateTime,DateTime>> exclude) {
            IEnumerable<Tuple<DateTime,bool>> dates=
                new[] { Tuple.Create(range.Item1.AddDays(-1),true),Tuple.Create(range.Item2.AddDays(1),false) }.
                Concat(exclude.SelectMany(r => new[] { Tuple.Create(r.Item1,false),Tuple.Create(r.Item2,true) })).
                OrderBy(d => d.Item1).ThenBy(d => d.Item2); //Get ordered list of time points where availability can change.
            DateTime firstFreeDate=default(DateTime);
            int count=1; //Count of unavailability intervals what is currently active. Start from 1 to threat as unavailable before range starts.
            foreach(Tuple<DateTime,bool> date in dates) {
                if(date.Item2) { //false - start of unavailability interval. true - end of unavailability interval.
                    if(--count==0) { //Become available.
                        firstFreeDate=date.Item1.AddDays(1);
                    }
                } else {
                    if(++count==1) { //Become unavailable.
                        DateTime lastFreeDate=date.Item1.AddDays(-1);
                        if(lastFreeDate>=firstFreeDate) { //If next unavailability starts right after previous ended, then no gap.
                            yield return Tuple.Create(firstFreeDate,lastFreeDate);
                        }
                    }
                }
            }
        }
    }
