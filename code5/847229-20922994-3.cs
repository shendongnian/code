    int id = Convert.ToInt32(txtStudentId.Text);
    XDocument xDoc = XDocument.Load("Test.xml");
    XElement student = xDoc.Descendants("Student").Where(x => (string) x.Attribute("ID") == id).FirstOrDefault();
    if (student != null)
    {
       string firstName = txtFirstName.Text;
       string lastName = txtLastName.Text;
       XElement first = new XElement("FirstName", firstName);
       XElement last = new XElement("LastName", lastName);
       student.Add(first);
       student.Add(last);
       xDoc.Save("Test.xml");
    }
