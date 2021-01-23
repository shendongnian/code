    static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 10, 20, 30, 40, 50, 60, 70};
            List<int> numbers2 = new List<int>();
            int counter1 = 0;
            int counter2 = numbers.Count - 1;
            int remainder = numbers.Count % 2 == 0 ? 1: 0;
            while (counter1-1 < counter2)
            {
                if (counter1 + counter2 % 2 == remainder)
                {
                    numbers2.Add(numbers[counter1]);
                    counter1++;
                }
                else
                {
                    numbers2.Add(numbers[counter2]);
                    counter2--;
                }
            }
            string s  = "";
            for(int a = 0; a< numbers2.Count;a++)
                s+=numbers2[a] + " ";
            Console.Write(s);
            Console.ReadLine();
        }
