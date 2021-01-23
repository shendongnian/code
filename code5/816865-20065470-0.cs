    void ClearAllTextBoxControls()
    {
        foreach (Control c in this.Controls)
        {
          if (c is TextBox)
             ((TextBox)c).Clear();
        }
    }
