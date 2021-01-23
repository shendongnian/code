      int gTabCounter = 0;     
    
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData.Equals(Keys.ShiftKey | Keys.Shift)) //you can set any key you want
                {
                    List<Control> controls = new List<Control>();
                    controls.Add(button1);
                    controls.Add(textBox1);                
                    if (gTabCounter > 1) gTabCounter = 0;
                    controls[gTabCounter].Focus();
                    gTabCounter++;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
