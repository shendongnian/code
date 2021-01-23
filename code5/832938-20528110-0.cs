         private void btnAdopt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Complete Adoption?", "Found a Happy Home!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
    
                if (lstAnimals.SelectedIndex >= 0)
    {
                    lstAnimals.Items.Remove(lstAnimals.SelectedItem);  
    XDocument xDoc = XDocument.Load("test.xml");
                xDoc.Descendants("Animal").Where(x => x.Element("Name").Value.ToString() == lstAnimals.SelectedItem ).Remove();
                xDoc.Save("test1.xml"); 
    
    }                                                      
    
            }
            else
            {
                return;
            }
    
      
