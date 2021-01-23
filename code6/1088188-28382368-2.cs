    internal class B1
    {
        private string m_ti;
        public virtual string Ti { get { return m_ti; } set { m_ti = value; } }
        public B1()
        {
            m_ti = "Hello";
        }
        protected B1(String word)
        {
            m_ti = word;
        }
    }
    internal sealed class B2 : B1
    {
        public B2():base("kitty")
        {
            
        }
    }
