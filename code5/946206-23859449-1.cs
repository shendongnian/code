    public class Person
    {
        private int id;
        private string name;
    
        public Person(int m_id, string m_name)
        {
            id = m_id;
            name = m_name;
        }
    
        public int Id
        {
            get
            {
                return id;
            }
        }
    
        public string Name
        {
            get
            {
                return name;
            }
        }
        public overrides ToString()
        {
            return name;
        }
    }
