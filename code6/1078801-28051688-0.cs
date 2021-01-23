     var list = new List<EventRecords>();
     list.Add(new EventRecords{ TimeStamp = new DateTime(2014,1,1), Event = "1", Duration = new TimeSpan(1)});
     list.Add(new EventRecords { TimeStamp = new DateTime(2013, 1, 1), Event = "1", Duration = new TimeSpan(1) }); 
     list.Add(new EventRecords { TimeStamp = new DateTime(2014, 1, 1), Event = "2", Duration = new TimeSpan(1) });
     list.Add(new EventRecords { TimeStamp = new DateTime(2012, 1, 1), Event = "3", Duration = new TimeSpan(1) });
     var output = list.GroupBy(e => e.Event)
                .Select(e => new EventRecords
                {
                    Event = e.Key,
                    Duration = new TimeSpan(e.Sum(ee => ee.Duration.Ticks)),
                    TimeStamp = e.Select(ee => ee.TimeStamp).Min()
                });
