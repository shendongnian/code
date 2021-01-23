    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;
    
    namespace MEFConsoleTest {
    
        public class TestMEFClass {
    
            /// <summary>
            /// This counter should increment everytime the getter in the ExportString property gets called.
            /// </summary>
            private int counter = 0;
    
            [Export("Contract_Name")]
            string ExportMethod() {
                return ExportString;
            }
    
    
            public string ExportString {
    
                get {
                    return "ExportString has been called " + counter++.ToString();
                }
            }
    
            [Import("Contract_Name")]
            Func<string> ImportMethod;
    
            public string ImportString { get { return ImportMethod(); } }
    
            /// <summary>
            /// Default Constructor.
            /// Make a catalog from this assembly, add it to the container and compose the parts.
            /// </summary>
            public TestMEFClass() {
              
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
    
    
        }
        
        class Program {
    
            static void Main(string[] args) {
    
                TestMEFClass testClass = new TestMEFClass();
    
                for (int x = 0; x < 10; x++) {
                    Console.WriteLine(testClass.ImportString);
                }
    
                Console.ReadLine();
    
            }
        }
    }
