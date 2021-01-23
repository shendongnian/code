    var result = from device in
                     (
                         from d in DevicesRepository.GetAll()
                         select new 
                         { 
                             Device = d, 
                             AddedDate = EntityFunctions.TruncateTime(d.Added) 
                         }
                     )
                 orderby device.AddedDate
                 group device by device.AddedDate into g
                 select new
                 {
                     Date = g.Key,
                     Count = g.Count()
                 };
