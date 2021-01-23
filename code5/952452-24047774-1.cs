        protected void Button1_Click(object sender, EventArgs e)
        {
            int value1=0, value2=0;
            foreach (Control c in myradiolist.Controls)
            {
                if (c is RadioButtonList)
                {
                    RadioButtonList rbl = (RadioButtonList)c;
                    
                    if(rbl.SelectedValue.Equals("1"))
                        value1++;
                    if (rbl.SelectedValue.Equals("2"))
                        value2++; 
                }
            }           
        }
