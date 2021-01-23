        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string type = comboBox1.Text;
            string age = comboBox2.Text;
            var an = XElement.Load(@"Animals.xml")
            .Descendants("Animal")
            .Where(a=>a.Element("Type").Value == type && a.Element("Age").Value == age)
            .OrderBy(xe => (xe.Element("Name").Value))
            .ToList<XElement>();
        }
          foreach (var a in an)
            lstAnimals.Items.Add(new Animal()
            {
                name = a.Element("Name").Value.ToString(),
                type = a.Element("Type").Value,
                age = a.Element("Age").Value
            });
