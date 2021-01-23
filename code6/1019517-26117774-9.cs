    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace DropDown
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    List<Columns> list = new List<Columns>();
                    for (int i = 0; i < 10; i++)
                    {
                        list.Add(new Columns
                        {
                            MainAccount = "1" + i,
                            MainDescription = "Main Account Desc" + i,
                            Concatenate = string.Format("{0} | {1}", "1" + i, "Main Account Desc" + i)
                        });
                    }
    
                    DropDownList1.DataSource = list;
                    DropDownList1.DataValueField = "MainDescription";
                    DropDownList1.DataTextField = "Concatenate";
                    DropDownList1.DataBind();
                }
            }
    
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                TextBox1.Text = DropDownList1.SelectedValue.ToString();
            }
         
        }
    }
