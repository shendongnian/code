    if (!System.IO.File.Exists("D:\\Employees.xml"))
    {
        XElement element = new XElement("Employees");
        element.Save("D:\\Employees.xml");
    }
    XElement doc = XElement.Load("D:\\Employees.xml");
    XElement employee = new XElement("Employees",
                                        new XElement("Employee",
                                                        new XElement("Person",
                                                                    new XElement("Name",
                                                                                textBox1.Text),
                                                                    new XElement("Designation",
                                                                                textBox2.Text),
                                                                    new XElement("EmployeeID",
                                                                                textBox3.Text),
                                                                    new XElement("Email",
                                                                                textBox4.Text))));
    doc.Add(employee);
    doc.Save("D:\\Employees.xml");
