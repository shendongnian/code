     var selecteditems = this.SelectedItems;
     for(int i = selecteditems.Count-1; i>=0; i-- )
     {
        ItemBox ouritem = (ItemBox)this.ItemContainerGenerator.ContainerFromItem(this.SelectedItems[i]);
         XmlDataProvider prov = this.DataContext as XmlDataProvider;
         XmlNode MainNode = prov.Document.SelectSingleNode("//MainNode");
         MainNode.RemoveChild(selecteditems[i] as XmlNode);
     }
