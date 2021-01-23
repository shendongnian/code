            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");
            XmlNodeList senergy = doc.SelectNodes("NewDataSet/Synergy");
            foreach (XmlNode node in senergy)
            {
                TreeNode senergyNode = new TreeNode("senergy");
                senergyNode.Nodes.Add(node.SelectSingleNode("INDATE").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("INTIME").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("OUTTIME").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("OUTDATE").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("LUNCH").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("EFFORTS").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("OPERATIONS").InnerText);
                senergyNode.Nodes.Add(node.SelectSingleNode("COMMENTS").InnerText);
                tvSenergy.Nodes.Add(senergyNode);
            }
