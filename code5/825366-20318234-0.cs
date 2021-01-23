            List<Employee> list = new List<Employee>();
            list.Add(new Employee("Walter White", "yes"));
            list.Add(new Employee("Bob Smith", "no"));
            list.Add(new Employee("Walter Junior", "no"));
            //get first employee after Bob with status "yes"
            Employee result = list.SkipWhile(e => e.Name != "Bob Smith") // skip people until Bob Smith
                             .Skip(1) // go to next person
                             .SkipWhile(e => e.Status != "yes") // skip until status equal 'yes'
                             .FirstOrDefault(); // get first person, if any
            if (result == null)
            {
                //get the first employee in list with status "yes"
                result = list.SkipWhile(e => e.Status != "yes") // skip until status equal 'yes'
                             .FirstOrDefault(); // get first person, if any
                if (result == null)
                {
                    //get Bob Smith if no employee has status "yes"
                    result = list.SkipWhile(e => e.Name != "Bob Smith")
                            .FirstOrDefault();                               
                }
            }
