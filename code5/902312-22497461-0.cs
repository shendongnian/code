    using System;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main( string[] args )
            {
                XDocument doc = XDocument.Load( "XMLFile1.xml" );
    
                var dobs= doc.Descendants( "DOB" );
    
                foreach ( var item in dobs)
                {
                    Console.WriteLine( item .Value );
                }
                Console.ReadLine();
            }
        }
    }
