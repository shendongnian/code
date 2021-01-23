    // LayoutAttribute.cs
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FixedLengthFileReader
    {
        [AttributeUsage(AttributeTargets.Field)]
        class LayoutAttribute : Attribute
        {
            private int _index;
            private int _length;
    
            public int index
            {
                get { return _index; }
            }
    
            public int length
            {
                get { return _length; }
            }
    
            public LayoutAttribute(int index, int length)
            {
                this._index = index;
                this._length = length;
            }
        }
    }
