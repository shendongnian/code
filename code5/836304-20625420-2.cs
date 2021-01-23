    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""PropA"": [ 1.0, 2.0, 3.0, 4.0 ],
                ""PropB"": [ 5.0, 6.0, 7.0, 8.0 ]
            }";
            try
            {
                Tester t = JsonConvert.DeserializeObject<Tester>(json),
                                                  new VectorConverter());
                DumpObject("PropA", t.PropA);
                DumpObject("PropB", t.PropB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
        }
        static void DumpObject(string prop, object obj)
        {
            if (obj == null)
            {
                Console.WriteLine(prop + " is null");
            }
            else
            {
                Console.WriteLine(prop + " is a " + obj.GetType().Name);
                if (obj is Vector4)
                {
                    Vector4 vector = (Vector4)obj;
                    Console.WriteLine("   X = " + vector.X);
                    Console.WriteLine("   Y = " + vector.Y);
                    Console.WriteLine("   Z = " + vector.Z);
                    Console.WriteLine("   W = " + vector.W);
                }
                else if (obj is JToken)
                {
                    foreach (JToken child in ((JToken)obj).Children())
                    {
                        Console.WriteLine("   (" + child.Type + ") " 
                                                 + child.ToString());
                    }
                }
            }
        }
    }
    
