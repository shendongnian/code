     class Program
        {
            static object reftypedata = "I am Testing. ";
            static int valuetypeData = 10;
    
            static void Main(string[] args)
            {
    
                CalcValue(valuetypeData);
                CalcValuewithRef(ref valuetypeData);
                Calcobject(reftypedata);
    
    
                Console.ReadKey();
    
            }
    
            public static void CalcValue(int i)
            {
                Console.WriteLine("Value Type.....");
                Console.WriteLine("before Processing i={0}", i);
                i = 100;
                Console.WriteLine("After Processing i={0}", i);
                Console.WriteLine("After Processing valueTypeData = {0}", valuetypeData);
    
            }
            public static void CalcValuewithRef(ref int i)
            {
                Console.WriteLine("Value with Ref Type.....");
                Console.WriteLine("before Processing i={0}", i);
                i = 100;
                Console.WriteLine("After Processing i={0}", i);
                Console.WriteLine("After Processing valueTypeData = {0}", valuetypeData);
    
            }
            public static void Calcobject(object value)
            {
                Console.WriteLine("Reference Type.....");
                Console.WriteLine("before Processing value={0}", value);
                value = "Default Value Has been Changed.";
                Console.WriteLine("After Processing value={0}", value);
                Console.WriteLine("After Processing reftypedata={0}", reftypedata);
    
    
            }
        }
