    string userName = textBox1.Text;
    string password = textBox2.Text;
    XDocument xDoc = XDocument.Load(@"C:/users.xml");
    var userControl = (from u in xDoc.Descendants("User") 
                        where u.Element("Username").Value == userName
                             && u.Element("Password").Value == password
                               select u).Any();
    if(userControl)
    {
        // validated...
    } else {
     // User doesn't exist or password wrong
    }
