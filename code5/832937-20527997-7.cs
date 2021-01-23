            string text = lstAnimals.SelectedItem.ToString();
            string animalName = text.Substring(0, text.IndexOf("is")).Trim();           
            XDocument xDoc = XDocument.Load("Animals.xml"); //here is your filepath
            XElement element = (from x in xDoc.Descendants("Animal")
                where x.Element("Name").Value == animalName  
                select x).First();
            element.Remove();
            xDoc.Save("Animals.xml");
            lstAnimals.Items.Remove(lstAnimals.SelectedItem);
