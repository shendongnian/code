    var result = from x in db.Prices
    			 let t = (from p in db.Prices select new { x.Date, x.BananaPrice, x.ApplePrice }
                 select new List<dataLine>
                 {
                     new dataLine() {
                         key = "ApplePrices",
                         values = t1.Select(t => Tuple.Create(t.Date, t.BananaPrice))
                     }
                 };
