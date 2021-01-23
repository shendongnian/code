    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    namespace WebApplication3
    {
        public partial class Example : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var data = new List<Browser>
                {
                    new Browser {
                        RenderingEngine = "Trident",
                        Name = "Internet Explorer 4.0",
                        Platforms = "Win 95+",
                        EngineVersion = "4",
                        CssGrade = "X"
                    },
                    new Browser {
                        RenderingEngine = "Trident",
                        Name = "Internet Explorer 5.0",
                        Platforms = "Win 95+",
                        EngineVersion = "5",
                        CssGrade = "C"
                    }
                };
                dataTable.DataSource = data;
                dataTable.DataBind();
                // tell gridview to wrap header row in a THEAD
                dataTable.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        class Browser
        {
            public string RenderingEngine { get; set; }
            public string Name { get; set; }
            public string Platforms { get; set; }
            public string EngineVersion { get; set; }
            public string CssGrade { get; set; }
        }
    }
