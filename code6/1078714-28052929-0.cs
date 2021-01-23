            GetControl(this.Master.Controls);
        }
        private void GetControl(ControlCollection cc)
        {
            foreach (var v in cc)
            {
                if (v is Control && (v as Control).HasControls())
                {
                    GetControl((v as Control).Controls);
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
  
