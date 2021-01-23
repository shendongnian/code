    var convertedBars =
            bars.GroupBy(b => b.TimeStamp.Date).Select(g => g.GroupBy(b2 => (int)(b2.TimeStamp.TimeOfDay.TotalMinutes / 60))).Select(gb => new Bar()
            {                
                TimeStamp = gb.FirstOrDefault().FirstOrDefault().TimeStamp,
                Open = gb.FirstOrDefault().FirstOrDefault().Open,
                Low = gb.SelectMany(bd => bd).Min(ibd => ibd.Low),
                High = gb.SelectMany(bd => bd).Max(ibd => ibd.High),
                Close = gb.LastOrDefault().LastOrDefault().Close,
            });
