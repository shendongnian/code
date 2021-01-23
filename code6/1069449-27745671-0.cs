    class StudentClass
    {
        DBclass x = new DBclass();
        MySqlConnection conn=  null;
        public StudentClass()
        {
            conn = new MySqlConnection(x.ConString);
        }
        public void add()
        {
        }
        public void update()
        {
        }
        public void remove()
        {
        }
    }
