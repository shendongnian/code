      public static void displayList<T>(this List<T> list)
        {
            Console.Write("[");
            foreach (T t in list)
            {
                Console.Write(t);
            }
            Console.WriteLine("]");
        }
