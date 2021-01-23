            List<TextBox> txtBoxs = new List<TextBox>();
            foreach (Control ctl in splitContainer1.Panel2.Controls){
                TextBox txtBox = ctl as TextBox;
                if (txtBox != null)
                {
                    txtBoxs.Add(txtBox);
                }
            
            }
