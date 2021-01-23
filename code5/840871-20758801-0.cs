    class Program
    {
        private static bool _pathological = true;
        private static bool Pathological
        {
            get
            {
                return (_pathological = !_pathological);
            }
        }
        static void Main(string[] args)
        {
            DoElseIf();
            DoSwitch();
            Console.WriteLine("Work's done!");
            Console.ReadLine();
        }
        static void DoSwitch()
        {
            switch (Pathological)
            {
                case true:
                    //Console.WriteLine("true");
                    break;
                case false:
                    //Console.WriteLine("false");
                    break;
                default:
                    Console.WriteLine("WTF (Switch)!");
                    break;
            }
        }
        static void DoElseIf()
        {
            // R# offers Convert to Switch on the below if, which results
            // in the code in DoSwitch, which has *different* behaviour
            if (Pathological == true)
            {
                //Console.WriteLine("true");
            }
            else if (Pathological == false)
            {
                //Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("WTF (Else-if)!");
            }
        }
    }
