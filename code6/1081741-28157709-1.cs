    private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            AzadIndustryEntities1 Db = new AzadIndustryEntities1();
            Products product = new Products();
            Products.ProductName = txtProductName.Text;
            Db.Products.Add(product);
            Db.SaveChanges();
            MessageBox.Show("Record Inserted");
        }
