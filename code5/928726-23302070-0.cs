        using System;
        using System.Collections.Generic;
        using System.Data;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    		DataTable table = new DataTable();
    
    		DataColumn col1 = new DataColumn("ID");
    		DataColumn col2 = new DataColumn("Name");
    		DataColumn col3 = new DataColumn("Checked");
    		DataColumn col4 = new DataColumn("Description");
    		DataColumn col5 = new DataColumn("Price");
    		DataColumn col6 = new DataColumn("Brand");
    		DataColumn col7 = new DataColumn("Remarks");
    
    		col1.DataType = System.Type.GetType("System.Int32");
    		col2.DataType = System.Type.GetType("System.String");
    		col3.DataType = System.Type.GetType("System.Boolean");
    		col4.DataType = System.Type.GetType("System.String");
    		col5.DataType = System.Type.GetType("System.Double");
    		col6.DataType = System.Type.GetType("System.String");
    		col7.DataType = System.Type.GetType("System.String");
    
    		table.Columns.Add(col1);
    		table.Columns.Add(col2);
    		table.Columns.Add(col3);
    		table.Columns.Add(col4);
    		table.Columns.Add(col5);
    		table.Columns.Add(col6);
    		table.Columns.Add(col7);
    
    		DataRow row = table.NewRow();
    
    		row[col1] = 1100;
    		row[col2] = "Computer Set";
    		row[col3] = true;
    		row[col4] = "New computer set";
    		row[col5] = 32000.00;
    		row[col6] = "NEW BRAND-1100";
    		row[col7] = "Purchased on July 30,2008";
    
    		table.Rows.Add(row);
    		DataTable dt2 = new DataTable();
    		dt2 = table.Copy();
    		string str1 = string.Empty;
    		foreach (DataRow dr in table.Rows)
    		{
    			int i = 0;
    			foreach (DataColumn dc in table.Columns)
    			{
    				
    				ListItem newItem = new ListItem(dc.ColumnName.ToString(), i.ToString());
    				CheckBoxList1.Items.Add(newItem);
    				i++;
    			}
    		} 
    
    
        }
    }
