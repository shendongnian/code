        public class Content
        {
          private String _Texty;
          public String Texty
          {
            get{return _Texty;}
            set { _Texty = value; }
          }
          public List<String> Comb1{get ; set;}
          public List<String> Comb2 { get; set; }
          public Content(string t, List<String> comb1, List<String> comb2)
          {
            Texty = "Some Text";
            Comb1 = comb1;
            Comb2 = comb2;
          } 
        }
