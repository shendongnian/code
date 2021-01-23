    private void ImageButton1_Click(object sender, EventArgs e)
        {
          ContentPlaceHolder cp = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            UpdatePanel up1 = cp.FindControl("Upi") as UpdatePanel ;
            up1.Visible= true;//Write your logic here.
        }
