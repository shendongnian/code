    using System;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main( string[] args )
            {
                XDocument doc = XDocument.Load( "XMLFile1.xml" );
                List<string> emps_dob=new List<string>();
                var dobs= doc.Descendants( "DOB" );
    
                foreach ( var item in dobs)
                {
                    emps_dob.Add(item.Value);
                }
               
            }
        }
    }
