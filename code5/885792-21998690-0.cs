    if (int.TryParse(this.TextBox.Text,out num))
    {
      this.Tree.SetInfo(this.TextBox.Text);
      base.label.Text = base.TextBox.Text;
    }
    else
    {
      base.TextBox.Text = string.Empty;
      MessageBox.Show("Only Numbers Allowed", "Error");
    }
