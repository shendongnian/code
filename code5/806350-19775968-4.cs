            Dictionary<string, Datum> MyData = new Dictionary<string, Datum>();
            Datum info = new Datum
            {
                Topic = "Allocation of Race[3]",
                County = "Brown County",
                Allocated = 315,
                NotAllocated = 6551
            };
            MyData.Add(info.Topic + "-" + info.County, info);
