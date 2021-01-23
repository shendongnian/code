    class Program
    {
        static void Main(string[] args)
        {
            object[] Mathfunction = new object[] { '+','-','*','/'};
            Console.WriteLine("Enter");
            String input = Console.ReadLine();
            for(int i=0;i<4;i++)
            {
                String str = (Mathfunction[i].ToString());
                if (String.Equals(str,input))
                {
                    Console.WriteLine("done");
                    Console.ReadLine();
                }
            }
        }
