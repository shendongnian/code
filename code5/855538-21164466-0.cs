    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace NavAutomation
    {
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("5D83B4FE-45E6-410E-A075-AD635F5F0354")]
        [ComVisible(true)]
        public interface INavAutomation
        {
            string HelloWorld();
            object OpenThis();
        }
    
        [ComVisible(true)]
        [Guid("B7806CE5-862A-4407-9A3E-14CE8A9FB83A")]
        [ClassInterface(ClassInterfaceType.None)]
        public class NavAutomation : INavAutomation
        {
            public NavAutomation()
            {
            }
    
            public object OpenThis()
            {
                using (var form = new NAVForm())
                {
                    var result = form.ShowDialog();
                    return form.RetVal1;
                }
                
            }
        }
    }
