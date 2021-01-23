       public void ToggleButtons(bool enabled){
                foreach (Control c in this.Controls)
                {
                    
                        if (c is Button)
                        {
                            ((Button)c).Enabled = enabled;
                        }
                }
        }
