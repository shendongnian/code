    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1) {
                XmlTextReader xmlreader = new XmlTextReader(@"C:\save.xml");
                XmlNodeType nodetype;
                bool xmlReaderArmed = false;
                while (xmlreader.Read())
                {
                    nodetype = xmlreader.NodeType;
                    if (nodetype == XmlNodeType.Element)
                    {
                        if (xmlreader.Name == "Name")
                        {
                            xmlreader.Read();
                            if (xmlreader.Value == comboBox1.SelectedItem.ToString()) {
                                label1.Text = xmlreader.Value;
                                xmlReaderArmed = true; 
                            }
                        }
                        else if (xmlreader.Name == "Priority" && xmlReaderArmed)
                        {
                            xmlreader.Read();
                            label2.Text = xmlreader.Value;
                        }
                        else if (xmlreader.Name == "StartDate" && xmlReaderArmed)
                        {
                            xmlreader.Read();
                            label3.Text = xmlreader.Value;
                        }
                        else if (xmlreader.Name == "EndDateSoll" && xmlReaderArmed)
                        {
                            xmlreader.Read();
                            label4.Text = xmlreader.Value;
                        }
                        else if (xmlreader.Name == "EndDateIst" && xmlReaderArmed)
                        {
                            xmlreader.Read();
                            label5.Text = xmlreader.Value;
                        }
                        else if (xmlreader.Name == "Comment" && xmlReaderArmed)
                        {
                            xmlreader.Read();
                            label6.Text = xmlreader.Value;
                            xmlReaderArmed = false;
                        }
                        
                       
                    }
                }
                xmlreader.Close();
            }
