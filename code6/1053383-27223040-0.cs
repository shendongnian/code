    private void UpdateView(bool IsUpdateViewRequired)
    {
            
                if (IsUpdateViewRequired == true)
                {
                    this.Height = 210;
                    labelStatus.Text = string.Empty;
                    progressBar.Value = 0;
                    
                }
                else
                {
                    this.Height = 165;
                }
                buttonCancel.Visible = IsUpdateViewRequired;
                buttonStart.Visible = !IsUpdateViewRequired;
            
    }
