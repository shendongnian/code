       class Program
        {
            static void Main(string[] args)
            {
                Obj o = new Obj();
                o.Allocate(85000);
                Console.WriteLine(System.GC.GetGeneration(o));
                Console.WriteLine(System.GC.GetGeneration(o.items));
                Console.WriteLine(System.GC.GetGeneration(o.items2));
                Console.WriteLine(System.GC.GetGeneration(o.Data));
                Console.ReadLine();           
            }
    
            class Obj
            {
                public byte[] items = null;
    
                public byte[] items2 = null;
    
                public string Data = string.Empty;
    
                public void Allocate(int i)
                {
                    items = new byte[i];
                    items2 = new byte[10];
                    Data = System.Text.Encoding.UTF8.GetString(items);
                }
            }
        }
