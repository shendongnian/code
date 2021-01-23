    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ClassLibrary1
    {
        [Guid("BBF87E31-77E2-46B6-8093-1689A144BFC6")]
        [ComVisible(true)]
        public interface MyMiniSubs
        {
            int square(int x);
            int getCount();
        }
        [Guid("BBF87E31-77E2-46B6-8093-1689A144BFC7")]
        [ClassInterface(ClassInterfaceType.None)]
        public class Class1 : MyMiniSubs
        {
            int count;
            public Class1()
                {
                    count = 0;
                }
                [ComVisible(true)]
                public int square(int x)
                {
                    ++count;
                    return x * x;
                }
                [ComVisible(true)]
                public int getCount()
                {
                    return count;
                }
        }
    }
