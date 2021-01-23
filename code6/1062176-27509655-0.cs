       public class  Student : People
       {
           public int MathPoint { get; set; } 
       }
       public class Worker : People
       {
           public string WorkPlace { get; set; }
       }
       public class People
       {
           public string Name { get; set; }
           public int Age { get; set; }
           public string Country { get; set; }
       }
