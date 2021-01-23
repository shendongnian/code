    while (NodeIter.MoveNext())
            {
                lab3 lab = new lab3();
                XPathNavigator Items = NodeIter.Current;
                lab.PartNO = Items.SelectSingleNode("PartNo").ToString();
                lab.Description = Items.SelectSingleNode("Description").ToString();
                lab.UnitPrice = Items.SelectSingleNode("UnitPrice").ToString();
                lab.TotalCost = Items.SelectSingleNode("TotalCost").ToString();
      
              var CustomoptionNode = Items.SelectSingleNode("CustomOptions");
               if(CustomoptionNode != null)
    {
                lab.Size = CustomoptionNode .SelectSingleNode("Size").ToString();
                sb.Append(CustomoptionNode .SelectSingleNode("Color").ToString() + Environment.NewLine);
    }
    
                return lab;
            }
