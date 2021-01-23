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
