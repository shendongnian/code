        protected void Page_Load(object sender, EventArgs e)
        {
            GetControl(this.Master.Controls);
        }
        private void GetControl(ControlCollection cc)
        {
            foreach (Control v in cc)
            {
                if (v.HasControls())
                {
                    GetControl(v.Controls);
                }
                else
                {
                    if (v is TextBox)
                    {
                        string s = (v as TextBox).ID;
                    }
                }
            }
        }
  
