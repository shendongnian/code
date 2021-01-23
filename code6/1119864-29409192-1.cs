    public EmployeeAndManager GetData()
    {
        //Your Rest Code
         EmployeeAndManager em = new EmployeeAndManager();
         List<MyClass> emp = new List<MyClss>();
         List<MyClass> man= new List<MyClss>();
         while(reader.Read())
         {
             MyClass mc = new MyClass();
             mc.Id = reader["Id"].ToString();
             mc.Name = reader["Name"].ToString();
             emp.Add(mc);
         }
        reader.NextResult();
        while(reader.Read())
         {
             MyClass mc = new MyClass();
             mc.Id = reader["Id"].ToString();
             mc.Name = reader["Name"].ToString();
             man.Add(mc);
         }
        em.employees = emp;
        em.manager= man;
        return em;
      }
