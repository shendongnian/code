    using System;
    using System.Collections.Generic;
    namespace Webtest
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            private List<ProgramData> _programData = new List<ProgramData>
            {
                new ProgramData {ProgramID = 1, Program = "Program abc", CompanyName = "Company 3434"},
                new ProgramData {ProgramID = 2, Program = "Program def", CompanyName = "Company 3qa2434"},
            };
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    RpPrograms.DataSource = _programData;
                    RpPrograms.DataBind();
                }
            }
        }
        public class ProgramData
        {
            public int ProgramID { get; set; }
            public string Program { get; set; }
            public string CompanyName { get; set; }
        }
    }
