    public class Program
    {
        
        public static void Main(string[] args)
        {
            Class1 c = new Class1();
            Type testType = c.GetType();
            PropertyInfo[] prinfo = testType.GetProperties();
            string[] filetest=File.ReadAllLines("Class1.cs"); //put correct file path here
            int index=0,i=0;            
            foreach (PropertyInfo p in prinfo)
            {                
                while(i < filetest.Length )
                {
                    index = filetest[i].IndexOf(p.Name);
                    if (index > 0)
                    {
                        index = 0;
                        filetest[i]=filetest[i].Insert(0, "private " + p.PropertyType.ToString() + " _" + p.Name+";" + Environment.NewLine);
                    }
                    i++;
                }                  
                
            }
            File.WriteAllLines("Class1.cs", filetest);//put correct file path here
            Console.Read();
        }        
    }
