    class employee
    {
        int id = 1;
        string name = "chandru";
        string dept = "IT";
        public string Name
        {
            get { return name; }
            private set { name = value; }       //Restricted to modify name to outer this calss
        }
        public string DEPT
        {
            set { dept = value; }
        }
        public void display()
        {
            Console.WriteLine("ID: {0} Name: {1} and Dept: {2}", id, name, dept);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            employee e = new employee();
            e.DEPT = "CSE";
            Console.WriteLine(e.Name);
            e.display();
          ///  e.Name = "Prakash";        //you cannot modify becoz of Access specifies as private
        }
    }
