    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the exhibit number: ");
            string str = Console.ReadLine();
            int caseSwitch = int.Parse(str);
            switch (caseSwitch) 
            {
                case 1:
                    Console.WriteLine("polar bear ");
                    break;
                case 2:
                    Console.WriteLine("penquin ");
                    break;
                case 3:
                    Console.WriteLine("moose ");
                    break;
                case 4:
                    Console.WriteLine("reindeer ");
                    break;
                case 5:
                    Console.WriteLine("deer ");
                    break;
                case 6:
                    Console.WriteLine("turtle ");
                    break;
                case 7:
                    Console.Write("lion ");
                    break;
                case 8:
                    Console.WriteLine("fish ");
                    break;
                case 9:
                    Console.WriteLine("bug ");
                    break;
            }
        }
    }
}
