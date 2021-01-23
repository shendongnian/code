        static List<string> values = new List<string> { "A", "B", "C", "D", "E", "F" };
        static void Main(string[] args)
        {
            Console.WriteLine("Existing Values: A, B, C, D, E, F");
            string input = "";
            while (input != "exit")
            {
                input = Console.ReadLine();
                if (input == "")
                {
                    Console.WriteLine("Cannot Insert! Missing value");
                }
                else if (IsTest(input))
                {
                    Console.WriteLine("Not Inserted");
                   // return;
                }
                else {
                    values.Add(input);
                    Console.WriteLine("Inserted");
                    Console.WriteLine(String.Join(", ", values));
                }
                //BindReceivedBoxes();
                //ClearLabels();
                //Console.WriteLine(IsTest(input));
            }
        }
        static bool IsTest(string input)
        {
            bool isDuplicate = false;
            for (var i = 0; i < values.Count; i++)
            {
                if (input != values[i]) continue;
                // lblNotRawConsignmentNumber.Text = "BLAH";
                isDuplicate = true;
                break;
            }
            return !isDuplicate;
        } 
