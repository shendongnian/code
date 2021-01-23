    internal class B1
    {
        private string m_ti;
        public virtual string Ti { get{return m_ti;} set{m_ti = value;} }
        public B1()
        {
            m_ti = "Hello";
        }
    
     
    }
    
    internal sealed class B2 : B1
    {
        public B2()
        {
            Ti = "HelloKitty";
        }
    
        public override string Ti { get; set; } //<--"Hello" will be assigned first then "HelloKitty" will be assigned
    }
