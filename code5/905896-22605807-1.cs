    EmployeeList lstEmployee = null;
    
                XmlSerializer xs = new XmlSerializer(typeof(EmployeeList));
    
                StreamReader sr = new StreamReader("testEmployee.xml");
                lstEmployee = (EmployeeList)xs.Deserialize(sr);
                sr.Close();
                for (int i = 0; i < lstEmployee.Items.Count(); i++)
                {
                    MessageBox.Show(lstEmployee.Items[i].RES_NAME);
    
                }
