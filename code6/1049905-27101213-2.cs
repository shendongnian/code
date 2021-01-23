    public class Employee
    {
        public string Name { get; set; }
        public string Grade { get; set; }
    }
    static void Main(string[] args)
    {
        empDB empDB1 = new empDB();
        List<Employee> empLST1 = new List<Employee>();
        empDB1.loadLST(ref empLST1);
    }
    public class empDB
    {
        public void loadLst(ref List<Employee> loadedLST)
        {
            string query = "select name, grade from emp";
            try
            {
                MySqlConnection con = new MySqlConnection(ConnectionString);
                con.Open();
                MySqlDataReader rdr = null;
                MySqlCommand cmd = new MySqlCommand(query, con);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.Name = rdr["name"].ToString();
                    emp.Grade = rdr["grade"].ToString();
                    loadedLST.Add(emp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
