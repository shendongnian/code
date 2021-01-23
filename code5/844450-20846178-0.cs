    using System;
    
    namespace console {
        internal class Program {
            private static void Main( string[] args ) {
                int age;
                string answer;
    
                do {
                    Console.Clear();
                    Console.Write( "Please enter your age: " );
                    answer = Console.ReadLine();
                } while ( !int.TryParse( answer, out age ) );
    
                Console.WriteLine( string.Empty );
                Console.WriteLine( "Thanks, let's continue..." );
                Console.Read();
            }
        }
    }
