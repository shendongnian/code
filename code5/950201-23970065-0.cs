      public class VLANSPropertyClass
        {
            public string vname { get; set; }
    
            public int S_No { get; set; }
    
            public string vid { get; set; }
    
            public string ip { get; set; }
    
            public string vports { get; set; }
            public override string ToString()
            {
                return String.Format("Name: {0}, Serial {1}", vname, S_No);
            }
        }
