    private void Page_Load(object sender, EventArgs e)
    {
       if (!Sitecore.Context.PageMode.IsPageEditor)
       {
         litScript.Text="<script src=\"/js/vendor/jquery.bxslider.min.js\"></script>";
              
       }
    }
