    void MyConstructor()
    {
        listBox.ItemsSource = someCollection;
        listBox.ItemContainerGenerator.StatusChanged += 
            ItemContainerGenerator_StatusChanged;
    }
    
    void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
        // If containers have been generated
        if (listBox.ItemContainerGenerator.Status == 
            System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
        {
            // Remove event
            listBox.ItemContainerGenerator.StatusChanged -= 
                ItemContainerGenerator_StatusChanged;
    
            // Do whatever here
            foreach(var item in listBox.Items)
            {
                var item = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromItem(item);
                // do whatever you want with the item
            }
    
        }
    }
