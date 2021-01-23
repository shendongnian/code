     public static class Uitl {
        
        public static DateTime DateStart = default(DateTime);
    
        public Uitl (){
          if(DateStart == default(DateTime))
             DateStart = DateTime.Now.AddYears(-2).AddMonths(-1);
        
        }
        
     }
