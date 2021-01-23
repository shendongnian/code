    var xdoc = XDocument.Load("login.xml"); // load xml file into document
    var userName = (string)xdoc.Root.Element("Data1"); // get value of Data1 element
    var password = (string)xdoc.Root.Element("Data2");
    if (textbox1.Text != userName || textbox2.Text != password)
    {
        MessageBox.Show("Username and/or password is invalid");
        return;
    }
