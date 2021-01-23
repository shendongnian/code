         using System.Collections.Generic;
         using System.Linq;
         using System.Web;
         using System.Web.UI;
         using System.Web.UI.WebControls;
         using System.IO;
         using System.Data;
         using System.Data.SqlClient;
         using System.Data.OleDb;
         using System.Collections;
         using System.Web.Security;
         using System.Text;
         using System.Configuration;
         using System.Web.SessionState;
         using System.Windows;
         public partial class Default2 : System.Web.UI.Page
         {
         Table tblRecipients = new Table();
         DropDownList drd = new DropDownList();
         DropDownList drd1 = new DropDownList();
         protected void Page_Init(object sender, EventArgs e)
    {
        DataTable dtt = (DataTable)Session["griddata"];
        int n = dtt.Columns.Count;
        string[] drd1item = new string[n];
        string[] excel = new string[n];
        for (int i = 0; i < dtt.Columns.Count; i++)
        {
            excel[i] = dtt.Columns[i].ColumnName;
        }
        Session["exceldata"] = excel;
        ////saving sql database column names in an array variable
        DataTable dtt1 = (DataTable)Session["dbasecolumns"];
        int l = dtt1.Columns.Count;
        string[] drditem = new string[l];
        string[] sqlcolumn = new string[l];
        for (int j = 0; j < dtt1.Columns.Count; j++)
        {
            sqlcolumn[j] = dtt1.Columns[j].ColumnName;
        }
        Session["sqlcolumn"] = sqlcolumn;
        Session["l"] = l;
        //Table Creation
        Table mytable = new Table();
        mytable.Visible = true;
        mytable.GridLines = GridLines.Both;
        TableHeaderRow th = new TableHeaderRow();
        TableHeaderCell thc = new TableHeaderCell();
        TableHeaderCell thc1 = new TableHeaderCell();
        mytable.Rows.Add(th);
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        lbl1.Text = "Database";
        lbl2.Text = "Excel";
        thc.Controls.Add(lbl1);
        thc1.Controls.Add(lbl2);
        th.Cells.Add(thc);
        th.Cells.Add(thc1);
        for (int rowctr = 0; rowctr < sqlcolumn.Length; rowctr++)
        {
            TableCell mycell = new TableCell();
            TableCell mycell1 = new TableCell();
            for (int cellctr = 0; cellctr < 1; cellctr++)
            {
                //dropdown with database columns
                DropDownList drd = new DropDownList();
                drd.Items.Insert(0, new ListItem("--Select--", "0"));
                drd.ID = "dbaseid" + rowctr;
                for (int i = 0; i < sqlcolumn.Length; i++)
                {
                    drd.Items.Add(sqlcolumn[i]);
                    drditem[i] = sqlcolumn[i];
                }
                // drd.SelectedIndexChanged+=new EventHandler(drd1_SelectedIndexChanged);
                //dropdown with excel columns
                DropDownList drd1 = new DropDownList();
                drd1.ID = "excelid" + rowctr;
                for (int j = 0; j < excel.Length; j++)
                {
                    drd1.Items.Add(excel[j]);
                    drd1item[j] = excel[j];
                }
                // drd1.SelectedIndexChanged +=new EventHandler (drd1_SelectedIndexChanged);
                //session variable to store dropdown elements in an array
                //Table cells and rows addition 
                TableRow myrow = new TableRow();
                mycell.Controls.Add(drd);
                mycell1.Controls.Add(drd1);
                myrow.Cells.Add(mycell);
                myrow.Cells.Add(mycell1);
                mytable.Rows.Add(myrow);
                mytable.BorderStyle = BorderStyle.Solid;
            }
        }
        DynamicControlsHolder.Controls.Add(mytable);
    }
         protected void Button1_Click(object sender, EventArgs e)
    {
        Table mytable = new Table();
        mytable.GridLines = GridLines.Both;
        string s;
        foreach (Control ctl in DynamicControlsHolder.Controls)
        {
            if (ctl is Table)
            {
                Table tblnew = ctl as Table;
                {
                    foreach (Control ctrl in tblnew.Controls)
                    {
                        if (ctrl is TableRow)
                        {
                            TableRow trow = new TableRow();
                            TableRow tblrow = ctrl as TableRow;
                            {
                                
                                foreach (Control cntrl in tblrow.Controls)
                                {
                                    if (cntrl is TableCell)
                                    {
                                        TableCell tcell = new TableCell();
                                        TableCell tblcell = cntrl as TableCell;
                                        {
                                            foreach (Control cntrol in tblcell.Controls)
                                            {
                                                if (cntrol is DropDownList)
                                                {
                                                    DropDownList myddr = cntrol as DropDownList;
                                                    if (cntrol != null)
                                                    {
                                                        
       
                                                        
                                                       
                                                        s = myddr.SelectedItem.Text;
                                                        tcell.Text = s;
                                                        
                                                        
                                                    }
                                                }
                                                
                                            }
                                            
                                        }
                                        trow.Cells.Add(tcell);
                                    }
                                }
                                
                            }
                            
                            mytable.Rows.Add(trow);  
                        }
                    }
                }
            }
        }
        DynamicControlsHolder.Controls.Add(mytable);
    }
}
