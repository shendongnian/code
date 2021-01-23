    private void button2_Click(object sender, EventArgs e)//Button Buy clicking method
            {
                XmlDocument inventory = new XmlDocument();
                inventory.Load("Inventory.xml");
                string vacuumName = (string)vacuumsBox.SelectedItem;//vacuumBox is a comboBox that contains the vacuums names
                XmlNode rootElement = inventory.FirstChild.NextSibling;//first child is the xml encoding type tag not the root
                
                int quantity, newQuantity = 0;
                foreach (XmlNode device in rootElement.ChildNodes)
                {
                    if (String.Equals(device["NAME"].InnerText, vacuumName))
                    {
                        int number = Convert.ToInt32(vacuumsNumber.Value);//vacuumNumber is the name of the numeric up down
                        quantity = Int32.Parse(device["QUANTITY"].InnerText);
                        newQuantity = quantity + number;
                        device["QUANTITY"].InnerText = newQuantity.ToString();//Updating the QUANTITY node value.
                        inventory.Save("Inventory.xml");
                        continue;
                    }
                }
