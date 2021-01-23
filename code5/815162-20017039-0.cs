    foreach (System.Xml.XmlNode node in list)
    {
        if (node.Attributes["Name"].Value == comboBox1.SelectedValue.ToString())
        {
             node.RemoveChild(node);
        
             System.Windows.MessageBox.Show("Screen has been deleted.");
             if (comboBox1.Items.Count > 0)
             {
                 comboBox1.Items.Remove(comboBox1.SelectedValue.ToString());
                 comboBox1.SelectedIndex = 0;
             }
             docc.Save("test.xml");
             break; // break now only if the node is the expected one. 
       }
    }
