           using System;
           using System.Collections;
           using System.Collections.Generic;
           using System.Data;
           using System.Diagnostics;
           using System.ComponentModel;
           using YouApplication.DSItems;    //your dataset refernce
           
  
      Public Void LoadItems ()
       {
       TblItemTableAdapter item= new TblItemTableAdapter();
        DataTable items= item.GetItems();
       if (items.Rows.Count > 0) {
	Gridview1.DataSource = allowances;
	Gridview1.DataBind();
      }}
        protected void GridView1_RowUpdating(object sender,   System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
	        try {
   		TblItemTableAdapter item = new TblItemTableAdapter();
  		int item_id = txtItemId.Text;
		TextBox txtItemValue =         (TextBox)grdContact.Rows(e.RowIndex).FindControl("txtItemValue");
		  item.UpdateItems(txtItemValue.text, item_id);
		  Gridview1.EditIndex = -1;
		LoadItems();
	} catch (Exception ex) {
		lblStatus.Text = "Items Updated.";
	}
       }
           protected void GridView1_RowEditing(object sender,       System.Web.UI.WebControls.GridViewEditEventArgs e)
       {
	GridView1.EditIndex = e.NewEditIndex;
	LoadItems();
       }
      protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
      {
	GridView1.EditIndex = -1;
	LoadItems();
       }
