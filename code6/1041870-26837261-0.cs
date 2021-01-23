    namespace ConsoleApplication36
    { 
        class Program { 
        static void Main(string[] args) { 
        float Salary, a = 0; Salary= 300; if (Salary <= 100)
            
                        a = Salary * 0; // a = amount paid
            
                    Console.WriteLine("He Pays " + a);
            
                    if (Salary <= 200)
                        a = Salary * 5 / 100;
                    Console.WriteLine("He Pays " + a);
            
                    if (Salary <= 500)
                        a = Salary * 10 / 100;
                    Console.WriteLine("He Pays " + a);
            
                        if (Salary > 500)
                            a= Salary*15/100;
                        Console.WriteLine("He Pays " + a);
                        Console.In.ReadLine();
            
            
                }
            }
            }
