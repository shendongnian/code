    public class Person
    {
       public static void Main( string[] args)
        {
            StringBuilder a = new StringBuilder("Vish");
            StringBuilder b = new StringBuilder("Krish");
            StringBuilder[] arr = new  StringBuilder[2] { a,b };
            StringBuilder[] copied = new  StringBuilder[2];
          
            arr.CopyTo(copied, 0);
            StringBuilder[] cloned = arr.Clone() as  StringBuilder[];
            Console.WriteLine();
            copied[1] = copied[1].Append("_AppendedCopy");
            cloned[1] = cloned[1].Append("_AppendedClone");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
            Console.WriteLine();
            for (int i = 0; i < copied.Length; i++)
                Console.WriteLine(copied[i]);
            Console.WriteLine();
            for (int i = 0; i < cloned.Length; i++)
                Console.WriteLine(cloned[i]);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
    
