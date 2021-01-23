            string foo = "jason0123x40";
            string foo3 = "";
            for (int i = 0; i < foo.Length; i++)
            {
                if (char.IsDigit(foo[i]))
                    foo3 += foo[i];
            }
            Console.WriteLine(foo3);
            Console.ReadLine();
