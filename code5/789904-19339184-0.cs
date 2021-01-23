            while (aValue.IntValue != -99) //user has not stopped program
            { 
                if (aValue.IntValue > 10 || aValue.IntValue < 0) //valid value
                {
                    Console.WriteLine("Thank you! Please enter '-99' when you are ready to finsih.");
                    aValue.InValue = Console.ReadLine(); //read input
                    aValue.IntValue = int.Parse(aValue.InValue); //convert string to int
                    number[aValue.IntValue]++; //add input to corresponding array box
                }
                else 
                {
                    Console.WriteLine("You have entered an invalid value.");
                    aValue.InvalidValueCount()++;
                }
            }
