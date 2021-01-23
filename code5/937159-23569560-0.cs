    class Program
    {
        static void Main(string[] args)
        {
            string one = "Montr�al";
            string two = "Montréal";
            one = Translate(one);
            two = Translate(two);
            if (string.Equals(one, two, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Equal");
            }
            Console.ReadLine();
        }
        static string Translate(string input)
        {
            var output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                var charCode = (int) input[i];
                if (charCode == 65533) // char �
                    output[i] = (char)233; // é
                else
                    output[i] = input[i];
            }
            return new string(output);
        }
    }
