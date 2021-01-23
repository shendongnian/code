                    if (numbers[r, c] < 0)
                    {
                        Console.WriteLine(numbers.GetValue(r, c));
                        Console.WriteLine("Row: " + Array.IndexOf(numbers, r, c));
                        Console.WriteLine("Column: " + Array.IndexOf(numbers, c));
                    }
