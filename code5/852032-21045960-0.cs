    public class Person
    {
       public int PersonID;
       public string Name;
       // other fields will follow in future
    }
    
    public List<Person> GetPersonList()
    {
       List<Person> people = new List<Person>();
       // This is just as example, because in real code 
       // you get this table from a database
       DataTable dt = new DataTable();
       dt.Columns.Add("ID");
       dt.Columns.Add("Name");
    
       dt.Rows.Add(1,"John");
       dt.Rows.Add(2, "Mark");
       dt.Rows.Add(3, "Steve");
    
       // Loop over the rows and construct a Person instance for every row
       // Add that row to the List<Person> to return 
       foreach (DataRow dr in dt.Rows)
       {
           Person p = new Person() {PersonID =Convert.ToInt32(dr[0]), Name = dr[1].ToString());
           people.Add(p);
       }
       return people;
    }
