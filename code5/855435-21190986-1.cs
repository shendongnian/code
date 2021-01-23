    **The .cs file goes here :**
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class Test_ankit_27Oct_Research_step_by_step : System.Web.UI.Page
    {
        static int start_number_rows = 1; //initial counter default row as 1
        static int counter = start_number_rows;
        protected void Page_Init(object sender, EventArgs e)
       {
           ViewState["RowsCount"] = start_number_rows;
           Label1.Text = "Total Rows : "+counter.ToString();
        
      }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            generate_table();
        }
        else
        {
            //the below part of the code is required to distinguish between autopost back of textbox 
            //and the autopost back of button controls
        
            string CtrlID = string.Empty;
            if (Request.Form["__EVENTTARGET"] != null &&
                     Request.Form["__EVENTTARGET"] != string.Empty)
            {
                
                 generate_table();
                 // for all postbacks except external and internal clicks
            }
            else
            {
                
               
                //to check which button or image button click caused the postback
                foreach (string controlID in Request.Form)
                {
                    Control objControl = Page.FindControl(controlID);
                    if (objControl is Button)
                    {
                        CtrlID = objControl.ID;
                        if (CtrlID == "Button1")
                        {
                         
                            //now the call will go to Button1_Click function
                        }
                        if (CtrlID == "Button2")
                        {
                            
                            //now the call will go to Button2_Click function
                        }
                    }
                }
            }
           //then let the control flow to button click events
        }
    }
    protected void generate_table()
    {
       
        Table table = new Table();
        TableRow row;
        TableCell cell;
        TextBox tb;
        table.ID = "Table1";
        int s_rows = Convert.ToInt32(ViewState["RowsCount"].ToString());
        for (int k = 1; k <= s_rows; k++)
        {
            row = new TableRow();
            cell = new TableCell();
            tb = new TextBox();
            tb.ID = "tb_" + k;
            tb.TextChanged += new EventHandler(tb_TextChanged);
            tb.AutoPostBack = true;
            cell.Controls.Add(tb);
            row.Cells.Add(cell);
            table.Rows.Add(row);
        }
       PlaceHolder1.Controls.Add(table);
    }
    protected void setdata()
    {
        Table table = (Table)Page.FindControl("Table1");
        if (table != null)
        {
            
            foreach (TableRow tr in table.Rows)
            {
                foreach (TableCell tc in tr.Cells)
                {
                    foreach (Control ct in tc.Controls)
                    {
                        if (ct is TextBox)
                        {
                           
                            ((TextBox)ct).Text = Request.Form[ct.ID];
                        }
                        if (ct is DropDownList)
                        {
                            ((DropDownList)ct).Text = Request.Form[ct.ID];
                        }
                    }
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        counter++;
        Label1.Text = "Total Rows : "+counter.ToString();
        //Label1.Text = "Refreshed at " + DateTime.Now.ToString();
        int new_rows_count = Convert.ToInt32(ViewState["RowsCount"]) + 1; //add one rows at a time
        ViewState["RowsCount"] = new_rows_count;
        generate_table();
        setdata();        //set the values of any of the previously generated  controls
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
         counter=counter+2;
         Label1.Text = "Total Rows : " + counter.ToString();
        //Label1.Text = "Refreshed at " + DateTime.Now.ToString();
        
        int new_rows_count = Convert.ToInt32(ViewState["RowsCount"]) + 2; //add 2 rows at a time
        ViewState["RowsCount"] = new_rows_count;
        generate_table();
        setdata();        //set the values of any of the previously generated  controls
    }
    protected void tb_TextChanged(object sender, EventArgs e)
    {
       
        TextBox tb = (TextBox)sender;
        Label2.Text = "Text of textbox "+ tb.ID+ " changed to " + tb.Text;
      
    }
}
