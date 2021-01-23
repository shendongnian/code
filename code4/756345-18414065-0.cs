    using System;
    
    class Program {
        static void Main(string[] args) {
            
    
            Console.WriteLine("Please enter the 10 digit telephone number. ");
            string userInput = Console.ReadLine();
            // Maybe do some validation here, check the length etc
            Char output;
            foreach (Char c in userInput) {
                switch (c) {
                    case 'A':
                    case 'B':
                    case 'C':
                        output = '2';
                        break;
                    case 'D':
                    case 'E':
                    case 'F':
                        output = '3';
                        break;
                    case 'G':
                    case 'H':
                    case 'I':
                        output = '4';
                        break;
                    case 'J':
                    case 'K':
                    case 'L':
                        output = '5';
                        break;
                    case 'M':
                    case 'N':
                    case 'O':
                        output = '6';
                        break;
                    case 'P':
                    case 'Q':
                    case 'R':
                        output = '7';
                        break;
                    case 'S':
                    case 'T':
                    case 'U':
                        output = '8';
                        break;
                    case 'V':
                    case 'W':
                    case 'X':
                    case 'Y':
                    case 'Z':
                        output = '9';
                        break;
                    default:
                        output = c;
                        break;
                }
    
                Console.Write(output);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
