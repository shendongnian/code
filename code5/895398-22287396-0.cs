    public class MyClass
    {
        private string m_x;
        private string m_y;
        public MyClass(string x, string y)
        {
            m_x = x;
            m_y = y;
        }
        public override bool Equals(object obj)
        {
            var typed = obj as MyClass;
            if (typed == null) return false;
            return typed.m_x == m_x && typed.m_y ==m_y;
        }
        public override int GetHashCode()
        {
            return new {m_x, m_y}.GetHashCode();
        }
    }
