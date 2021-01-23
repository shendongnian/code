      public class Shirt{
        
        public Shirt(string color, string size, string sleeve)
        {
         Color =color;
         Size=size;
         Sleeve=sleeve;
         }
        public string Color {get;set;}
        public string Size {get;set}
        public string Sleeve {get;set}
        
        
        public override string ToString(){
          
         return string.Format("shirt is color :{0} , size :{1} and shleeve: {2}",Color,Size,Sleeve )
          
        }
      }
