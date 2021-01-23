            if (pReader.NodeType == XmlNodeType.Element)
            {
                if (pReader.HasAttributes)
                {
                    while (pReader.MoveToNextAttribute())
                    {
                        /* ...Here I want a label with attribute name not value)*/
                        Label lblAttribute = new Label();
                        lblAttribute.Text = pReader.Name;
                        TextBox txbAttribute = new TextBox();
                        txbAttribute.Text = pReader.Value;
                        Page.FindControl("form1").Controls.Add(txbAttribute);
                    }   
                    
                    // Move the reader back to the element node.
                    reader.MoveToElement();
                }
            }
