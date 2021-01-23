     var xmlPrev; // im assuming it is declared somewhere up here.      
    foreach (XmlNode xmlApp in xdoc.DocumentElement.ChildNodes)
                {
                //select the num attribute and if they match up...
                if (Convert.ToInt32(xmlApp.Attributes["num"].Value) == currappNum)
                {
                    //get the previous app node
                    if (xmlPrev == null)
                    {
                       //it must be the first element in the loop, so handle this however you need to.
                    }
                    //replace the description attribute
                    xmlPrev.Attributes["desc"].Value = txtDesc.Text;
                    //loop though the child nodes in xml app 
                    foreach (XmlNode xmlAppChild in xmlPrev.ChildNodes)
                    {
                        //replace all the info 
                        switch (xmlAppChild.Name)
                        {
                            case "appname":
                                xmlAppChild.InnerText = txtAppName.Text;
                                break;
                            case "version":
                                xmlAppChild.InnerText = txtVersion.Text;
                                break;
                            case "srcpath":
                                xmlAppChild.InnerText = txtSrcPath.Text;
                                break;
                            case "dstpath":
                                xmlAppChild.InnerText = txtDstPath.Text;
                                break;
                            default:
                                break;
                        }
                    }
                    //set the current num
                    currappNum = Convert.ToInt32(xmlPrev.Attributes["num"].Value);
                   }
                     xmlPrev = xmlApp; // Set the previous node here. Each time you loop through, the xmlPrev will be set to the previous element in the loop.
               }
            }
