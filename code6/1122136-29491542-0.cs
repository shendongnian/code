    using System;
    using System.Reflection;
    public class MarkerAttribute : Attribute {
    }
    [Marker]
    class Program {
        static void Main(string[] args) {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()) {
                foreach (Attribute attribute in type.GetCustomAttributes()) {
                    MarkerAttribute markerAttribute = attribute as MarkerAttribute;
                    if (markerAttribute != null) {
                        Console.WriteLine(type.FullName);
                    }
                }
            }
        }
    }
