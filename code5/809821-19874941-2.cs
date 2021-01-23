    var amount = new List<double>() { 2.5, 1.5, 3.5, 5.5 };
                var sum = 0.0d;
                foreach (var d in amount)
                {
                    sum += d;
                }
    
                Console.WriteLine(sum);
    
                amount.Sort();
                amount.Reverse();
    
                var i = 1;
                foreach (var d in amount)
                {
                    if (i > 3)
                        break;
    
                    Console.WriteLine("{0} is position {1}",d,i);
                    i++;
                }
    
                Console.ReadLine();
