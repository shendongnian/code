            string sPath = @"c:\Development\{0}";
            try
            {
                File.Copy(String.Format(sPath, "Model.edmx"), String.Format(sPath, "ModelTemplate.edmx"));
                File.Delete(String.Format(sPath, "Model.edmx"));
            }
            catch (Exception)
            {
                //no worry, file not found issues
            }
            using (var ctx = new ShopID.Models.ShopIDDb())
            {
                using (var writer = new XmlTextWriter(String.Format(sPath, "Model.edmx"), Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
            XmlDocument oldModel = new XmlDocument();
            oldModel.Load(String.Format(sPath, "ModelTemplate.edmx"));
            XmlDocument newModel = new XmlDocument();
            newModel.Load(String.Format(sPath, "Model.edmx"));
            var nsmgr = new XmlNamespaceManager(newModel.NameTable);
            nsmgr.AddNamespace("diagram", "http://schemas.microsoft.com/ado/2009/11/edmx");
            XmlNode node = oldModel.SelectSingleNode("//diagram:Diagrams", nsmgr).ChildNodes[0];
            XmlNode newNode = newModel.SelectSingleNode("//diagram:Diagrams", nsmgr);
            XmlNode importNode = newNode.OwnerDocument.ImportNode(node, true);
            newModel.ImportNode(importNode, true);
            newNode.AppendChild(importNode);
            newModel.Save(String.Format(sPath, "Model.edmx"));
            File.Delete(String.Format(sPath, "ModelTemplate.edmx"));
