    static void Main(string[] args)
        {
            List<string> lstStr = new List<string>();
            lstStr.Add("First");
            lstStr.Add("Second");
            Alter(lstStr);
            //Alter(ref lstStr);
            
            Console.WriteLine("---From Main---");
            foreach (string s in lstStr)
            {
                Console.WriteLine(s);
            }
            Alter2(ref lstStr);
            Console.WriteLine("---From Main after passed by ref---");
            foreach (string s in lstStr)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
        static void Alter(List<string> lstStr2)
        {
            lstStr2.Add("Third");
            Console.WriteLine("----From Alter----");
            foreach (string s in lstStr2)
            {
                Console.WriteLine(s);
            }
            lstStr2 = new List<string>();
            lstStr2.Add("Something new");
            Console.WriteLine("----From Alter - after the local var is assigned somthing else----");
            foreach (string s in lstStr2)
            {
                Console.WriteLine(s);
            }
        }
        static void Alter2(ref List<string> lstStr2)
        {
            lstStr2 = new List<string>();
            lstStr2.Add("Something new from alter 2");
            Console.WriteLine("----From Alter2 - after the local var is assigned new list----");
            foreach (string s in lstStr2)
            {
                Console.WriteLine(s);
            }
        }
    //----From Alter----
    //First
    //Second
    //Third
    //----From Alter - after the local var is assigned somthing else----
    // Something new
    // ---From Main---
    // First
    // Second
    // Third
    // ----From Alter2 - after the local var is assigned new list----
    // Something new from alter 2
    // ---From Main after passed by ref---
    // Something new from alter 2
