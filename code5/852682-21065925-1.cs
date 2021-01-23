    protected void btnAdd_Click(object sender, EventArgs e)
    {
    
        SSDataContext db = new SSDataContext();
        ActualStock myAdd = new ActualStock();
        var userId = Convert.ToInt32(Session["userid"]);
        if (!db.ActualStocks.Any(u => u.EAN == addSoeg.Text&&u.UserId == userId))
        {
            myAdd.EAN = addSoeg.Text;           
            myAdd.UserID = userId;
            myAdd.Quantity = 0;
            db.ActualStocks.InsertOnSubmit(myAdd);
            db.SubmitChanges();
    
        }
        myAdd = db.ActualStocks.Single(x => x.EAN == addSoeg.Text&&x.UserId == userId);
        myAdd.UserID = userId ;       
        myAdd.Quantity = myAdd.Quantity + Convert.ToInt32(quantity.Text);
        db.SubmitChanges();
        Response.Redirect(Request.RawUrl);
    }
