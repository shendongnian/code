    var list = vehicles as IList<Vehicle> ?? vehicles.ToList();
    if (!list.Any()) return;
    var currDate = DateTime.Now().toString("ddMMyyyy");
    
    var groups = list.Count / 1000;
    Parallel.For(0, groups + 1, groupNo => {
    
      var fileName  = "C:\\test\\" 
                    +  currDate 
                    + "_0" + groupNo
                    + ".xml";
      using (var sw = new StreamWriter(fileName))
      {
          var limit = Math.Min(groupNo * 1000 + 1000, list.Count);
          for (var i = groupNo * 1000, i < limit; i++)
          {
              var v = list[i];
              sw.WriteLine(ConvertCode.ToXml(v));
          }
      }
    
    });
