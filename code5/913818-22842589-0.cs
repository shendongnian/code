        static void Main(string[] args) {
            string numbers = "1234512345";
            int total = 0;
            int num; // out result
            for (int i = 0; i < numbers.Length; i++) {
                int.TryParse(numbers[i].ToString(), out num);
                total += num; // will equal 30
            }
            Console.WriteLine(total);
            total = 0;
            string alphanumeric = "1@23451!23cf47c";
            for (int i = 0; i < alphanumeric.Length; i++) {
                int.TryParse(alphanumeric[i].ToString(), out num);
                total += num; // will equal 32, non-numeric characters are ignored
            }
            Console.WriteLine(total);
            Console.ReadLine();
        }
