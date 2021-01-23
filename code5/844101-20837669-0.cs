    public Employee getEMP(string name1)
    {
        // left out some of your code intentionally
        da.SelectCommand = new SqlCommand("select * from pss where Emp_code='"+name1+"'", dbconn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dbconn.Close();
        return new Employee(ds);
    }
    public class Employee
    {
        public string Name { get; set; }
        /* Other properties ... */ 
        public Employee(DataSet dataset)
        {
            Name = ds.Tables[0].Rows[0][0].ToString();
            // etc
        }
    }
