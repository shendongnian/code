            public class LatestDataReduced
            {
                //[BsonIgnoreIfDefault]
                public String Id { get; set; }
                public int PlatformID { get; set; }
                public DateTime Date { get; set; }
                public double Depth { get; set; }
                public List<CodeValuePair> ParamValue { get; set; }
                public double Pressure { get; set; }
                public List<CodeValuePair> ParamValueInfo { get; set; }
                public string Roos { get; set; }
            }
