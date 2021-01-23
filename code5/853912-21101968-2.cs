    private void btDeletar_Click(object sender, RoutedEventArgs e)
    {
        if (ProductList.SelectedItem != null)
        {
            Product product = ProductList.SelectedItem as Product;
            db.Product.Remove(product);
            db.SaveChanges();
            // *** Side note, should db.SaveChanges be after this if statement?? ***
            if (SystemMessage.ConfirmDeleteProduct() == MessageBoxResult.No)
                return;
            SystemMessage.ProductDeleteSuccess();
            // Don't call UpdateList just remove the item from the list. 
            // This will raise the CollectionChanged event and the grid will respond accordingly.
            ProductList.Remove(product);
        }
        else
            SystemMessage.NoProductSelected();
    }
