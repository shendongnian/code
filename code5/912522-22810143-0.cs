    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
      var c=  this.Master.FindControl("lbl_cart") as System.Web.UI.HtmlControls.HtmlGenericControl;      
      c.InnerText = "12122112";
    }
