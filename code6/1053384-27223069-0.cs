     private void UpdateView(bool IsUpdateViewRequired)
     {
                Height =IsUpdateViewRequired? 210:165;
                buttonCancel.Visible = IsUpdateViewRequired;
                buttonStart.Visible = !IsUpdateViewRequired;
                if (IsUpdateViewRequired)
                {
                   labelStatus.Text = string.Empty;
                   progressBar.Value = 0;
                }            
    }
