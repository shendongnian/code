    namespace ConsoleApplication18
    {
        class Program
        {
            static void Main(string[] args)
            {
               
    
                Students s1 = new Students();
                s1.name = "John Doe";
                s1.age = 12m;
                s1.tag = "MM";
    
                Students s2 = new Students();
                s2.name = "Su";
                s2.age = 12m;
                s2.tag = "XX";
    
                Students s3 = new Students();
                s3.name = "Jane Doe";
                s3.age = 12m;
                s3.tag = "FM";
    
                Students[] arr = new Students[3];
                arr[0] = s1;
                arr[1] = s2;
                arr[2] = s3;
    
              
                //Main logic
                string result = "";
                //loop in all array elements
                for (int i = 0; i < arr.GetUpperBound(0)+1 ; i++)
                {
                    if (arr[i].tag == "MM") //Choose 0, 1 or more enteries with MM in tag
                    {
                        result = result + arr[i].name + " " + 
                                          arr[i].age.ToString() + " " + 
                                          arr[i].tag +
                                          "  Position:" + i.ToString() + 
                                          Environment.NewLine;
                    }
                    
                }
    
                if (result != "")
                {
                    Console.WriteLine(result);
                }
    
                Console.Read();
    
            }
        }
    
        public class Students
        {
            public string name;
            public decimal age;
            public string tag;
        }
    }
