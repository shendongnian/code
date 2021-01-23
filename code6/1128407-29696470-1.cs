    while (NodeIter.MoveNext())
            {
                lab3 lab = new lab3();
                XPathNavigator Items = NodeIter.Current;
                lab.PartNO = Items.SelectSingleNode("PartNo").ToString();
                lab.Description = Items.SelectSingleNode("Description").ToString();
                lab.UnitPrice = Items.SelectSingleNode("UnitPrice").ToString();
                lab.TotalCost = Items.SelectSingleNode("TotalCost").ToString();
      
              var CustomoptionNode = Items.SelectSingleNode("CustomOptions");
              string Color = string.Empty;
               if(CustomoptionNode != null)
           {
                lab.Size = CustomoptionNode .SelectSingleNode("Size").ToString();
                Color = CustomoptionNode .SelectSingleNode("Color").ToString();
                
          }
       sb.Append(Color  + Environment.NewLine);
    
                return lab;
       }
