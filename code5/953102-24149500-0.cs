    protected void Page_Load(object sender, EventArgs e)
            {
                var txt = new TextBox
                              {
                                  Text = "Initial Text"
                              };
    
                txt.TextChanged += ThisTextBoxChanged;
                form1.Controls.Add(txt);
            }
    
            private static void ThisTextBoxChanged(object sender, EventArgs e)
            {
                System.Diagnostics.Debugger.Break();
            }
