    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace MVCWeb
    {
        public partial class SO_GVSample : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    gvParent.DataSource = GetParentData();
                    gvParent.DataBind();
    
                    pnlForm.Visible = false;
                }
    
            }
    
            #region Events
    
            protected void gvParent_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "cmdSelect")
                {
                    gvChild.DataSource = GetChildData().Where(c => c.ParentID == Convert.ToInt32(e.CommandArgument));
                    gvChild.DataBind();
                                    
                    pnlForm.Visible = false;
                }
            }
    
            protected void gvChild_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "cmdCSelect")
                {
                    FormView1.DataSource = GetFormData().Where(c => c.ChildID == Convert.ToInt32(e.CommandArgument));
                    FormView1.DataBind();
    
                    pnlForm.Visible = true;
                }
            }
    
           
            #endregion
    
    
            #region Data Source
    
            private List<ParentClass> GetParentData()
            {
                return new List<ParentClass>()
                {
                    new ParentClass{ ID=1, Description="Parent Record 1"},
                    new ParentClass{ ID=2, Description="Parent Record 2"},
                    new ParentClass{ ID=3, Description="Parent Record 3"},
                    new ParentClass{ ID=4, Description="Parent Record 4"},
                    new ParentClass{ ID=5, Description="Parent Record 5"}
                };
            }
    
            private List<ChildClass> GetChildData()
            {
                return new List<ChildClass>()
                {
                    new ChildClass{ ID=11, ParentID=1,  Description="Child Record 11"},
                    new ChildClass{ ID=12, ParentID=1,  Description="Child Record 12"},
                    new ChildClass{ ID=22,ParentID=2, Description="Child Record 22"},
                    new ChildClass{ ID=23,ParentID=2, Description="Child Record 23"},
                    new ChildClass{ ID=33,ParentID=3, Description="Child Record 3"},
                    new ChildClass{ ID=44,ParentID=4, Description="Child Record 4"},
                    new ChildClass{ ID=55, ParentID=5,Description="Child Record 55"},
                    new ChildClass{ ID=56, ParentID=5,Description="Child Record 56"}
                };
            }
    
            private List<FormViewClass> GetFormData()
            {
                return new List<FormViewClass>()
                {
                    new FormViewClass{ ID=111, ChildID=11,  Description="FormView Record 11"},
                    new FormViewClass{ ID=222,ChildID=22, Description="FormView Record 22"},
                    new FormViewClass{ ID=333,ChildID=33, Description="FormView Record 3"},
                    new FormViewClass{ ID=444,ChildID=44, Description="FormView Record 4"},
                    new FormViewClass{ ID=555, ChildID=55,Description="FormView Record 55"},
                     new FormViewClass{ ID=111, ChildID=12,  Description="FormView Record 11"},
                    new FormViewClass{ ID=222,ChildID=23, Description="FormView Record 22"},            
                    new FormViewClass{ ID=555, ChildID=56,Description="FormView Record 55"},
                };
            }
    
            public class ParentClass
            {
                public int ID { get; set; }
    
                public string Description { get; set; }
            }
    
            public class ChildClass
            {
                public int ID { get; set; }
    
                public int ParentID { get; set; }
    
                public string Description { get; set; }
            }
    
            public class FormViewClass
            {
                public int ID { get; set; }
    
                public int ChildID { get; set; }
    
                public string Description { get; set; }
            }
    
            #endregion
    
                
        }
    }
  
