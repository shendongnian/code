    var output = 0;
                string input = "BB6050C9";
                char[] values = input.ToCharArray();
                foreach (char letter in values)
                {
                    // Get the integral value of the character. 
                    int value = Convert.ToInt32(letter);
                    // Convert the decimal value to a hexadecimal value in string form. 
                    string hexOutput = String.Format("{0:X}", value);
                    Console.WriteLine("Hexadecimal value of {0} is {1}", letter, hexOutput);
                    output += Convert.ToInt32(hexOutput);
                }
    
                Console.WriteLine(output);
                Console.ReadKey();
