     double price = Convert.ToDouble(Request.Form["textboxe" + i ]);
     double quantity = Convert.ToDouble(Request.Form["textboxq" + i]);
     double total = price * quantity;
     TextBox1.Text = Convert.ToString(total);
    
    //you need to use only request.Form rather than .value attribute
     string szValue =  Request.Form["txt1"]
