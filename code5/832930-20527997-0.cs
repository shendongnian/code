            string name = lstAnimals.SelectedItem.Text;
            string type = lstAnimals.SelectedItem.SubItems[0].Text;
            string age = lstAnimals.SelectedItem.SubItems[1].Text;
            XDocument xDoc = XDocument.Load("animals.xml"); //here is your filepath
            XElement element = (from x in xDoc.Descendants("Animal")
                where x.Element("Name").Value == name  //and other conditions...
                select x).First();
            element.Remove();
            xDoc.Save("animals.xml");
