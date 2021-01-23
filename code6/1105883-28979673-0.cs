                //  Root Node
                XmlNode RootNode = this.xDoc.CreateElement("DataGridView");
                xDoc.AppendChild(RootNode);
                //  AutoSize
                XmlNode AutoSize= this.xDoc.CreateElement("AutoSize");
                VisitID.InnerText = true;
                RootNode.AppendChild(AutoSize);
               //  PropertyTWoToSave
                XmlNode PropertyTWoToSave= this.xDoc.CreateElement("PropertyTWoToSave");
                VisitID.InnerText = 500;
                RootNode.AppendChild(PropertyTWoToSave);
                if (!Directory.Exists(this.FilePath))
                    Directory.CreateDirectory(this.FilePath);           
              StreamWriter sw = new StreamWriter(this.FilePath + "\\" +                 this.FileName + ".xml");
            try
            {
                
                this.xDoc.Save(sw);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Flush();
                sw.Dispose();
            }
