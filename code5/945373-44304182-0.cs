            WhoAmIResponse userResponse = (WhoAmIResponse)service.Execute(new WhoAmIRequest());
            QueryScheduleRequest req = new QueryScheduleRequest
            {
                ResourceId = userResponse.UserId,
                Start = DateTime.Today,
                End = DateTime.Today.AddDays(1),
                TimeCodes = new TimeCode[] { TimeCode.Available, TimeCode.Unavailable, TimeCode.Busy, TimeCode.Filter }
            };
            QueryScheduleResponse resp = service.Execute(req) as QueryScheduleResponse;
            bool free = true;
            foreach (TimeInfo timeInfo in resp.TimeInfos)
            {
                if (timeInfo.SubCode == SubCode.Break && DateTime.UtcNow > timeInfo.Start && DateTime.UtcNow < timeInfo.End)
                {
                    free = false;
                    Console.WriteLine("on break");
                }else if (timeInfo.SubCode == SubCode.Schedulable && DateTime.UtcNow < timeInfo.Start && DateTime.UtcNow > timeInfo.End)
                {
                    free = false;
                    Console.WriteLine("out of work hours");
                }
            }
            if (free)
            {
                Console.WriteLine("Free");
            }
            Console.ReadKey();
