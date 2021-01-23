    private void BtnSubmit_Click(object sender, RoutedEventArgs e)
     {
       AzadIndustryEntities1 Db = new AzadIndustryEntities1();
       Product p = db.Products.Create()
       p.ProductName = txtProductName.Text;
       db.Products.Add(p);
       db.SaveChanges();
     }
