    statistics.Select(a => new
               {
                 a.Type, 
                 Min = a.Min.ToTask(),
                 Max = a.Max.ToTask(),
                 Avg = a.Avg.ToTask()
               })
               .Subscribe(async x =>
               {
                 var min = await x.Min;
                 var max = await x.Max;
                 var avg = await x.Avg;
                 ...
               });
