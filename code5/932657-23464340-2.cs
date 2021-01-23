    protected void Button1_Click(object sender, System.EventArgs e)
            {
               // Session["choice"] = RadioButtonList1.SelectedItem.Text;
                if (RadioButton1.Checked)
                {
                    Session["choice"] = "Choice 1";
                }
    
                if (RadioButton2.Checked)
                {
                    Session["choice"] = "Choice 2";
                }
                if (RadioButton3.Checked)
                {
                    Session["choice"] = "Choice 3";
                }
              
            }
