    using System;
    using System.Collections;
    using System.Xml;
    using System.IO;
    using System.Windows.Forms;
    
    
    namespace NWT_Projekt
    {
        public class TestClass : MarshalByRefObject, NWT_Projekt.Command
        {
            public MainForm f;
    
            public TestClass()
            {
                f = Form.ActiveForm as MainForm;
            }
            public void Execute()
            {
                //do something
            }
        }
    }
