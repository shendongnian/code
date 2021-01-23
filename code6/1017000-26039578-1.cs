         public partial class webpartusercontrolclass : UserControl
    {
        public wpCustomToolPart addCustomToolPart { get; set; }
        public int  intNumberofAnnouncement { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.intNumberofAnnouncement = addCustomToolPart.NumberofAnnouncement;  
        }
    }
