    foreach (string item in kryptonListBox1.Items)
    {
         foreach (EveAI.Product.ProductType Prod in MyApi.EveApiCore.ProductTypes)
         {
             if (Prod.MarketGroup != null)
             {
                 if (Prod.MarketGroup.Name == item)
                 {
                    if (Prod.Name.Contains("Blueprint") == false)
                    {
                        kryptonListBox2.Items.Add(Prod.Name);
                        Products.Add(Prod);
                    }
                 }
             }
         }
    }
    foreach (EveAI.Product.ProductType T in Products)
    {
      kryptonListBox3.Items.Add(MyApi.EveApiCore.GetIdForObject(T));
    }
