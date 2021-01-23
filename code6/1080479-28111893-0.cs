    class YourClass
    {
         XmlDocument xmlMembers;
    
         private void btnAdd_Click(object sender, EventArgs e)
            {
                XmlNode member = xmlMembers.CreateElements("member"); //Causes error
        
                XmlAttribute attID = xmlMembers.CreateAttribute("id"); //Causes error
                attID.Value = MPlayID;
                member.Attributes.Append(attID);
        
                XmlAttribute attNick = XmlMembers.CreateAttribute("nick"); //Causes error
                attNick.Value = MNick;
                member.Attributes.Append(attNick);
            }
        
            private void Form_Member_Load(object sender, EventArgs e)
            {
                xmlMembers = new XmlDocument();
                XmlNode rootNode = xmlMembers.CreateElement("members");
                xmlMembers.AppendChild(rootNode);
            }
        }
