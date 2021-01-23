    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace OtherGuysDll
    {
        public class OtherGuysCode
        {
    
            /// <summary>
            /// Example of an IDisposable that doesn't run in a using statement or call the Dispose method in a finally 
            /// block.  Used to simulate a third-party .dll that doesn't properly deallocate resources and can cause 
            /// problematic accumulation in RAM over time.
            /// </summary>
            public OtherGuysCode()
            {
                /*
                    The code below demonstrates a chunk of unmanged code that doesn't deallocate resources 
                    properly.  Feel free to substitute any code that will cause a memory leak below if you'd prefer a 
                    different example.
                */
    
                StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\output.txt");
                sw.WriteLine(DateTime.Now.ToString());
                sw.Close();
            }
    
        }
    }
