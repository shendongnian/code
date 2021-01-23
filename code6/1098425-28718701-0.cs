	protected void MyLinkButton_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvr in MyGridView.Rows)
        {
            int radioItemValue = 0;
            string radioItemText = "";
			
			foreach (DataControlFieldCell dc in gvr.Cells)
            {
                string cellName = dc.ContainingField.ToString();
                string cellText = dc.Text;
                switch (cellName)
                {
                    case ("MyColumnNameWithRadioButtonList"):
                        try
                        {
                            var tb = (TextBox)gvr.FindControl("MyTextBox");
                            var rbl = (RadioButtonList)gvr.FindControl("MyRadioButtonList");
                            var rb = (ListControl)rbl;
                            radioItemValue = Convert.ToInt32(rb.SelectedValue);
                            radioItemText = rb.SelectedItem.Text;
                        }
                        catch (Exception ex)
                        {
                            //error trapping required?
                        }
                        break;
					case ("AnotherColumn"):
						//do some other stuff?
						break;
					default:
						break;
                }
            }
		}
