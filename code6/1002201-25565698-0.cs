    System.Reflection.PropertyInfo[] properties = typeof(tblEmployee).GetProperties();
            tblEmployee objEmployee = new tblEmployee();
            for(int i=0;i<properties.Length;i++)
            {
                properties[i].SetValue(objEmployee, 1);//First param is obj and 2nd is value for the column which will be saved in db.
            }
