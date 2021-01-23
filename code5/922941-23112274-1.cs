    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    
    public partial class SOA : System.Web.UI.Page {
        private List<String> GetNames() {
            return Enumerable.Range(1, 10).Select(x => string.Format("Checkbox_{0}", x)).ToList();
        }
        protected void Page_Load(object sender, EventArgs e) {
            CreateCheckboxes();
            if(IsPostBack)
                ReadCheckboxes();
        }
    
        private void ReadCheckboxes() {
            var selectedName = GetNames().Where(x => Request.Form[x] == "checked");
        }
    
        private void CreateCheckboxes() {
            foreach(var name in GetNames()) {
                var checkbox = new HtmlInputCheckBox();
                checkbox.ID = name;
                checkbox.Value = "checked";
                checkbox.Name = name;
                checkboxesHolder.Controls.Add(checkbox);
                checkboxesHolder.Controls.Add(new LiteralControl(name));
            }
        }
    }
