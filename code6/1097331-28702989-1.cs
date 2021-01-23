    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DisposeSample
    {
        /*
            A new instance of this class is created by the New Domain object 
            in each of the Form1's Scan Timer Tick Event.
        */
        public class CreateNewDomainInstanceClass : MarshalByRefObject
        {
    
            /// <summary>
            /// This method creates a new instance of the problem DLL.
            /// </summary>
            public void RunOtherGuysCode()
            {
                // Create a new instance of the Other Guy's Code class
                OtherGuysDll.OtherGuysCode ogc = new OtherGuysDll.OtherGuysCode();
            }
    
        }
    }
