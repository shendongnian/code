    using System;
    
    namespace WebApplication1
    {
      public partial class SimpleTestPage : System.Web.UI.Page
      {
        public string AnotherUrl {  get; set; }
        protected void Page_Load( object sender , EventArgs e )
        {
          this.GoogleLink.NavigateUrl = "http://www.google.com/" ;
          this.AnotherUrl = "http://www.leevalley.com/";
        }
      }
    }
