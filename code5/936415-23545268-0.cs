    namespace ABC
    {
    
        public partial class ClassA
        {
               public ClassA(XYZ.ClassA classToConvert)
               {
                 this.First_name = classToConvert.First_name,
                 this.Last_Name = classToConvert.Last_Name
               }
    
               public string First_name { get; set; }
               public string Last_Name { get; set; }
        }
    }
