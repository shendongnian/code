    public class SomeClass : SomeBaseClass
    {
    
     string string1="";
     string string2 ="";  // defined on class level
    private void checkXML(string _title)
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Directory\test.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "myElement":
                                string title = reader["title"];
                                if (title == _title)
                                {
                                    string1 = (reader["publisher"]);
                                    string2 = (reader["author"]); // set values here
                                }
                                break;
                        }
                    }
                }
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            checkXML("The Cookbook");
            MessageBox.Show(string1); //Now aviable here"
            MessageBox.Show(string2); //Available here"
        }
    }
