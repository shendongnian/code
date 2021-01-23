    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                Console.WriteLine("Type you first number :");
                                                 
                Console.WriteLine("Type you second number :");
                
                       
                Console.WriteLine("Enter the operation + (addition), - (soustraction), * (multiplication), / (division)");
                string stringOperation = Console.ReadLine();
    
                            
                switch (operation)
                {
                    case 1:
                        result = firstNumber + secondNumber;
                        break;
    
                    case 2:
                        result = firstNumber - secondNumber;
                        break;
    
                    case 3:
                        result = firstNumber * secondNumber;
                        break;
    
                    case 4:
                        result = firstNumber / secondNumber;
                        break;
    
                   }
               
            }
        }
    }
