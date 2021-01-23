    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
    
            if (!IsPostBack)
            {
                var dt = new System.Data.DataTable();
                dt.Columns.Add("Col1");
                dt.Rows.Add("Hi");
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
    
            CreateDynamicControles();
               
         
        }
    
        public void CreateDynamicControles()
        {
            var count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
    
                    UpdatePanel UP_AmountToBuy = new UpdatePanel();
                    UP_AmountToBuy.ContentTemplateContainer.Controls.Clear();
                    UP_AmountToBuy.Triggers.Clear();
                    UP_AmountToBuy.UpdateMode = UpdatePanelUpdateMode.Conditional;
                    UP_AmountToBuy.ChildrenAsTriggers = false;
                    UP_AmountToBuy.Attributes["runat"] = "server";
    
                    //Create and add TextBox
                    TextBox TB_AmountToBuy = new TextBox();
                    TB_AmountToBuy.Text = "0";
                    TB_AmountToBuy.TextChanged += new EventHandler(TB_AmountToBuy_TextChanged);
                    TB_AmountToBuy.Attributes["OnTextChanged"] = "TB_AmountToBuy_TextChanged";
                    TB_AmountToBuy.Attributes["runat"] = "server";
                    TB_AmountToBuy.AutoPostBack = true;
                    TB_AmountToBuy.ViewStateMode = System.Web.UI.ViewStateMode.Enabled;
                    TB_AmountToBuy.ID = "buyID" + count;
                    UP_AmountToBuy.ContentTemplateContainer.Controls.Add(TB_AmountToBuy);
    
                    //Create and add AsyncPostBackTrigger
                    AsyncPostBackTrigger APBT_trig = new AsyncPostBackTrigger();
                    APBT_trig.EventName = "TextChanged";
                    APBT_trig.ControlID = TB_AmountToBuy.ID;
                    UP_AmountToBuy.Triggers.Add(APBT_trig);
    
                    Label newLBL = new Label();
                    newLBL.Text = "123";
                    newLBL.Attributes["runat"] = "server";
                    UP_AmountToBuy.ContentTemplateContainer.Controls.Add(newLBL);
    
                    row.Cells[0].Controls.Add(UP_AmountToBuy);
                     count++;
                }
            }
        }
       
    
    
        public void TB_AmountToBuy_TextChanged(object sender, EventArgs e)
        {
            ((sender as TextBox).Parent.Controls[1] as Label).Text = (sender as TextBox).Text;
        }
    }
 
