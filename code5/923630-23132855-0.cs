    var convertedBars = from myData in 
                         (
                           from b in bars 
                           group b by b.Timestamp.Date into g
                           select g
                          )
                         group myData by (int) myData.TimeStamp.TimeOfDay.TotalMinutes / 60 into barData
                         select new Bar()
                         {
                                    TimeStamp = barData.FirstOrDefault().FirstOrDefault().TimeStamp,
                                    Open = barData.FirstOrDefault().FirstOrDefault().Open,
                                    Low = barData.SelectMany(bd => bd.Min(ibd => ibd.Low).Min(bd => bd.Low),
                                    High = barData.SelectMany(bd => bd.Max(ibd => ibd.High).Max(bd => bd.High),
                                    Close = barData.LastOrDefault().LastOrDefault().Close,
                         };
