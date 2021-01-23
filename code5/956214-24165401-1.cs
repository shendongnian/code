    public class Test
    {
        public static void Main()
        {
            var list = new List<String> { "Che", "Chr", "chi", "a", "A" };
    
            // Any other way to sort goes here
            list.Sort(new MyComparer());
           // list.Sort((s1, s2) => s1.CompareTo(s2));
    
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadKey();
        }
    }
    Output
    
    a
    A
    chi
    Che
    Chr
