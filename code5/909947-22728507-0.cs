                EventListingResponse evl = new EventListingResponse();
            evl.result = new List<events>();
            evl.result.Add(new events() { id = "1", name = "test1", startDate = "2014-03-31T12:30:03" });
            evl.result.Add(new events() { id = "2", name = "test2", startDate = "2014-03-31T14:30:03" });
            evl.result.Add(new events() { id = "3", name = "test3", startDate = "2014-05-31T16:30:03" });
            evl.result.Add(new events() { id = "4", name = "test4", startDate = "2014-05-31T12:30:03" });
            var dated_EventListResponse = evl.result.Select(t => new { date = DateTime.Parse(t.startDate), MyEvent = t });
            var grouped_EventListResponse = dated_EventListResponse.GroupBy(g => g.date.Month);
            foreach (var group in grouped_EventListResponse)
            {
                Console.WriteLine("Filter: " + group.Key);
                foreach (var grouped_event in group)
                {
                    Console.WriteLine("\t" + grouped_event.MyEvent.name);
                }
            }
