    private void btnSave_Click(object sender, EventArgs e)
    {
        name = characterTextBox.Text;
        age = characterAgeTextBox.Text;
        XmlUtility.Save(this);
    }
    class XmlUtility
    {
        public static void Save(Form1 form)
        {
            string name = form.name;
            string age = form.age;
            var file = "xmlfile.xml";
            var doc = XDocument.Load(file);
            var newElement = new XElement("player", name,
                new XElement("age", age));
            doc.Element("players").Add(newElement);
            doc.Save(file);
        }
    }
