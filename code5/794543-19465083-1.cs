    private void button1_Click(object sender, EventArgs e)
                {
        
            List<Emp> myData = new List<Emp>(); // (Employee, Age, Department);
                        myData.Add(new Emp{Employee = "Bill",Age ="34",Department = "IT"});
                        myData.Add(new Emp { Employee = "Fred", Age = "23", Department = "ACCOUNTS" });
                        myData.Add(new Emp { Employee = "Jane", Age = "44", Department = "SALES" });
                        myData.Add(new Emp { Employee = "Sally", Age = "56", Department = "IT" });
                        myData.Add(new Emp { Employee = "Harry", Age = "33", Department = "ACCOUNTS" });
            
                        var results = from p in myData
                          group p by p.Department into g
                          select new { Department = g.Key, Result = g.Count() };
            
                        var filteredData = myData.Where(x => results.Where(y => y.Result > 1).Select(z=> z.Department).Contains(x.Department));
        }
