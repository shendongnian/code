    public void ClearLabelText()
    {
        if (StatusText.InvokeRequired)
        {
             this.Invoke((MethodInvoker)delegate
             {
                StatusText.Text = "Something should happen";
             });
        }
        else
        {
          StatusText.Text = "Something should happen";
        }
    }
