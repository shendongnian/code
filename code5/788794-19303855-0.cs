    public IEnumerable<ChartClass> get(string ID, string buildname, string placeholder)
        {
            var context = new Entities();
            var metrics = from c in context.VSTS_CODE_METRICS
                          where c.BUILD_NAME == buildname && c.OBJECT_TYPE == "Namespace"
                          group c by c.BUILD_ID into g
                          select new ChartClass
                          {
                              Build_ID = g.Key,
                              BuildTrim = "2",//g.Key,
                              Index = g.Average(c => c.MAINTAINABILITYINDEX_).Value
                          };
            /*foreach (var i in metrics)
            {
                int num = i.BuildTrim.LastIndexOf('_');
                i.BuildTrim = "2";
            }*/       
            return metrics;
        }
