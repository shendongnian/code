    using System;
    
    namespace ConsoleApplication1 {
        class Program {
            static void Main(string[] args) {
                String original = "1.23.4.34";
                String[] components = original.Split('.');
                int value = Int32.Parse(components[components.Length - 1]) + 1;
                components[components.Length - 1] = value.ToString();
                String newstring = String.Join(".",components);
                Console.WriteLine(newstring);
            }
        }
    }
