    private void Button1_EnabledChanged(object sender, System.EventArgs e)
        {
             Button1.ForeColor = Button1.enabled == false ? System.Drawing.Color.Red :System.Drawing.Color.Black;
             
        }
