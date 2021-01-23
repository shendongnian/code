    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    
    namespace WebApplication1
    {
        public partial class Gridview : System.Web.UI.Page
        {
            public class Make
            {
                public int Id { get; set; }
                public string Name { get; set; }
    
                public List<Make> GetMake()
                {
                    return new List<Make>() 
                    {
                        new Make { Id = 1, Name = "Ford" },
                        new Make { Id = 2, Name = "BMW" },
                        new Make { Id = 3, Name = "Lamborghini" }
                    }.ToList();
                }
            }
    
            public class Models
            {
                public int ModelId { get; set; }
                public int MakeId { get; set; }
                public string Name { get; set; }
    
                public List<Models> GetModels()
                {
                    return new List<Models>()
                    {
                        new Models { ModelId=1, MakeId=1, Name="Ford Truck 1"}, 
                        new Models { ModelId=2, MakeId=1, Name="Ford Truck 2"},
                        new Models { ModelId=3, MakeId=1, Name="Ford Truck 3"},
                        new Models { ModelId=4, MakeId=3, Name="Gollarado"},
                        new Models { ModelId=5, MakeId=3, Name="Murcillago"}
                    };
    
                }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    // Temporary data fetched through a list. In production you will fetch data from the database
                    Make make = new Make();
                    ddlMake.DataSource = make.GetMake();
                    ddlMake.DataTextField = "Name";
                    ddlMake.DataValueField = "Id";
                    ddlMake.DataBind();
    
                    if(ViewState["dt"]!=null)
                    {    
                        DataTable dt = ViewState["dt"] as DataTable;
                        gvItems.DataSource = dt;
                    }
                }
            
            }
    
            protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Filter second dropdown list
                Models model = new Models();
                ddlModels.DataSource = model.GetModels().Where(s => s.MakeId == int.Parse(ddlMake.SelectedValue));
                ddlModels.DataTextField = "Name";
                ddlModels.DataValueField = "ModelId";
                ddlModels.DataBind();
            }
    
            protected void btnAddConsignment_Click(object sender, EventArgs e)
            {
                // Bind gridview to temporary data & store inside viewstate
                DataTable dt = null;
    
                if (ViewState["dt"] == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Id", typeof(int)));
                    dt.Columns.Add(new DataColumn("Color", typeof(string)));
                    dt.Columns.Add(new DataColumn("Tires", typeof(string)));
                    dt.Columns.Add(new DataColumn("NOS", typeof(string)));
                    dt.Columns["Id"].AutoIncrement = true;
                    dt.Columns["Id"].AutoIncrementSeed = 1;
                }
                else
                    dt = ViewState["dt"] as DataTable;
    
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
    
                gvItems.DataSource = dt;
                gvItems.DataBind();
    
                ViewState["dt"] = dt;
                
    
            }
    
            protected void cbSameAsStock_CheckedChanged(object sender, EventArgs e)
            {
                // Get your checkbox from gridview's selected row
                CheckBox cbTemp = sender as CheckBox;
                if (cbTemp != null)
                {
                    // If selected, append selected model name to textboxes
                    if (cbTemp.Checked)
                    {
                        var selectedModel = ddlModels.SelectedItem.Text;  // your selected car model
                        GridViewRow gr = ((CheckBox) sender).NamingContainer as GridViewRow;
                        if (gr != null)
                        {
                            TextBox txt1 = gr.FindControl("TextBox1") as TextBox;
                            TextBox txt2 = gr.FindControl("TextBox2") as TextBox;
                            TextBox txt3 = gr.FindControl("TextBox3") as TextBox;
    
                            txt1.Text = "Same as stock "+ selectedModel;
                            txt2.Text = "Same as stock " + selectedModel;
                            txt3.Text = "Same as stock " + selectedModel;
                        }
    
                    }
                }
            }
           
            }
     }
