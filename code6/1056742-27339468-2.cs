    //create a new Employee object
        try // Exception handling to ensure that incorrect data type cannot be entered into text box creating a new product
           {
                Products newProd = new Products(this.textProdID.Text);
                newProd.ProductName= this.textProdName.Text;
                newProd.ProductQuantity= Convert.ToInt32(this.textProdQuantity.Text);
                // add the input range validation 
                if (newProd.ProductQuantity<=0) throw new ArgumentException ("Quantity must be a positive number.");
    
                newProd.ProductPrice= Convert.ToDouble(this.textProdPrice.Text);
                ProductList.Add(newProd);
                MessageBox.Show(newProd.ProdName + " has been added to the product list");
            }
         catch
         {
            MessageBox.Show("Format entered into text box Is incorrect please check and try again");
         }
