	private void SetListBox(string value)
	{
      if (this.InvokeRequired)
      {
        SetListBoxDelg dlg = new SetListBoxDelg(this.SetListBox);
        this.Invoke(value);
		return;
      }
      listBox1.Items.Add(value);
	}
