    private void BtnSubmit_Click(object sender, RoutedEventArgs e)
     {
       AzadIndustryEntities1 Db = new AzadIndustryEntities1();
       Product p = new Product() { p.ProductName = txtProductName.Text };
       db.AddToProducts(p);
       db.SaveChanges();
     }
