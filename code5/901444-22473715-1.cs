    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["lbSelectedMovies"] = lbDisplay;
        Session["lbSelectedSnacks"] = lbSelected;
        if(Session["lbSelectedMovies"]!=null)
        {
           (ListBox) lbTempMovies = (ListBox)Session["lbSelectedMovies"];
           if(lbTempMovies==null || lbTempMovies.Items.Count==0)
           {
              Response.Redirect("RingU6POSReview.aspx");
           }
        }
        else
        {
          Response.Redirect("RingU6POSReview.aspx");
        }
    }
