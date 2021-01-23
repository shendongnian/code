    switch (comboBox1.Text)
            {
             case "All" :   //No conditions
                var an = XElement.Load(@"Animals.xml")
            .Descendants("Animal")
            .OrderBy(xe => (xe.Element("Name").Value))
            .ToList<XElement>();
                    break;
                case "Dog":
                    var an = XElement.Load(@"Animals.xml")
            .Descendants("Animal")
            .Where(a=>a.Element("Type").Value ="Dog")
            .OrderBy(xe => (xe.Element("Name").Value))
            .ToList<XElement>();
                    break;
                case "Cat":
                    var an = XElement.Load(@"Animals.xml")
            .Descendants("Animal")
            .Where(a=>a.Element("Type").Value ="Cat")
            .OrderBy(xe => (xe.Element("Name").Value))
            .ToList<XElement>();
                    break;
            }
