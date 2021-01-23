    public Product Product {
      set { 
        thisProduct = value;
        imgProduct.ImageUrl = value.ImageUrl;
        lblProductName.Text = value.CompanyName + "<br/>" + 
          value.ProductName + "&nbsp" + value.Model;
        lblProductPrice.Text = value.Price.ToString() + "&nbsp" + "israeli shekel";
      }
    }
