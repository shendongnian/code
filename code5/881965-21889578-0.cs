    protected void Button_Click(object sender, EventArgs e)
    {
       string url = TestMode ? 
          "https://www.sandbox.paypal.com/us/cgi-bin/webscr" : 
          "https://www.paypal.com/us/cgi-bin/webscr";
    
       var builder = new StringBuilder();
       builder.Append(url);
       builder.AppendFormat("?cmd=_xclick&business={0}", HttpUtility.UrlEncode(Email));
       builder.Append("&lc=US&no_note=0&currency_code=USD");
       builder.AppendFormat("&item_name={0}", HttpUtility.UrlEncode(ItemName));
       builder.AppendFormat("&invoice={0}", TransactionId);
       builder.AppendFormat("&amount={0}", Amount);
       builder.AppendFormat("&return={0}", HttpUtility.UrlEncode(ReturnUrl));
       builder.AppendFormat("&cancel_return={0}", HttpUtility.UrlEncode(CancelUrl));
       builder.AppendFormat("&undefined_quantity={0}", Quantity);
       builder.AppendFormat("&item_number={0}", HttpUtility.UrlEncode(ItemNumber));
       
       Response.Redirect(builder.ToString());
    }
