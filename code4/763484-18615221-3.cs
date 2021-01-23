    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.Data;
    
    public partial class GridBulkEdit : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //Create a data table to bind the grid
            DataTable DT = new DataTable();
            DT.Columns.Add("PrimaryKeyField");
            DT.Columns.Add("CurrentValue");
    
            DataRow DR1 = DT.NewRow();
            DR1["PrimaryKeyField"] = 1;
            DR1["CurrentValue"] = "value one";
            DT.Rows.Add(DR1);
    
            DataRow DR2 = DT.NewRow();
            DR2["PrimaryKeyField"] = 2;
            DR2["CurrentValue"] = "value two";
            DT.Rows.Add(DR2);
    
            DataRow DR3 = DT.NewRow();
            DR3["PrimaryKeyField"] = 3;
            DR3["CurrentValue"] = "value three";
            DT.Rows.Add(DR3);
    
            grid.DataSource = DT;
            grid.DataBind();
        }
    
        protected void Update_Button_Click(object sender, EventArgs e)
        {
            TestOutput_Label.Text = "";
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                HiddenField PrmaryKeyForThisRow_HiddenField = grid.Rows[i].FindControl("PrmaryKeyForThisRow_HiddenField") as HiddenField;
                CheckBox UpdateThisRow_CheckBox = grid.Rows[i].FindControl("UpdateThisRow_CheckBox") as CheckBox;
                if (UpdateThisRow_CheckBox.Checked)
                {
                    UpdateRow(PrmaryKeyForThisRow_HiddenField.Value);
                }
            }       
        }
    
        private void UpdateRow(object PrimaryKey)
        {
            object NewValue = NewValue_TextBox.Text;
            //Execute SQL query to update row with the passed PrimaryKey with the NewValue
            TestOutput_Label.Text += "<br/> Update row whose PrimaryKey is: " + PrimaryKey + " with new value: " + NewValue;
        }
    }
