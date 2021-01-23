    protected void GridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
    
          Label drpValue =
          (Label)this.GridView1.Rows[e.NewSelectedIndex].Cells[1].FindControl("Label1");
          Lbl1.Text = drpValue.Text; 
          Lbl2.Text = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;
          Lbl3.Text = GridView1.Rows[e.NewSelectedIndex].Cells[3].Text;
    
    }
