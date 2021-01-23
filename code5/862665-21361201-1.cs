    using System;
    
    namespace WebApp.Attributes
    {
        public partial class CompositeControl : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                if (!string.IsNullOrEmpty(this.HiddenFieldClientId))
                {
                    hdnAge.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    hdnAge.ID = this.HiddenFieldClientId;
                }
            }
    
            public string Name
            {
                get
                {
                    return tbxName.Text;
                }
                set
                {
                    tbxName.Text = value;
                }
            }
    
            public int Age
            {
                get
                {
                    return int.Parse(hdnAge.Value);
                }
                set
                {
                    hdnAge.Value = value.ToString();
                }
            }
    
            public string HiddenFieldClientId { get; set; }
        }
    }
