    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace newProg
    {
        class YourApp
        {
            private Phone inputPhone()
            {
                Console.Write("Enter the phone manufacturer: ");
                string manufacturer = Console.ReadLine();
                Console.Write("Enter the phone model: ");
                string model = Console.ReadLine();
                Console.Write("Is it cordless? [Y or N]: ");
                bool hasCord = Console.ReadLine().ToUpper() == "Y";
                Console.Write("Enter the phone price: ");
                double price = Convert.ToDouble(Console.ReadLine());
                return new Phone {
                    Manufacturer = manufacturer,
                    Model = model,
                    HasCord = hasCord,
                    Price = price;
                };
            }
        static void outputPhones(List<Phone> phones)
        {
            foreach (var index = 0; index < phones.Length; index++)
            {
                Console.WriteLine("==Phone #{0}==", index);
                Console.WriteLine(phone.ToString());
            }
            Console.WriteLine("Number of phones entered: {0}", phones.Length);
        }
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>();
            bool Continue = true;
            do
            {
                phones.Add(inputPhone());
                Console.Write("Would like to process another phone? [Y or N]: ", Continue);
                Continue = Console.ReadLine().ToUpper() == "Y";
            } while (Continue == true);
            if (Continue == false)
            {
                outputPhones(phones);
            }
        }
    }
