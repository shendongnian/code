         var output = Enumerable.Range(0, 1).Select(o => 
                  new {
                     GreenAppleCount = db.Apples.Count(a => a.Color == "Green"),
                     Yuck = db.Bananas.Any(b => b.Age > 10
                      });
