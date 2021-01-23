    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Protectedmemberinabstractclassex
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
    }
    namespace A
    {
    
        public abstract class BaseClass
        {
            protected virtual string GetData()
            {
                throw new NotImplementedException();
            }
        }
    }
    
    namespace B  //includes a reference to A
    {
    
    
        abstract class DerivedClassA : A.BaseClass
        {
            
        }
    
    
        internal class DerivedClassB : DerivedClassA
        {
            public void write()
            {
                base.GetData();
            }
        }
    }
