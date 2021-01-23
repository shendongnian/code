    private void CreateButton()
    {
      Button btn = new Button();
      btn.ID = "btnNum1";
      btn.Text = "Edit";
      btn.Click += btnTest_Click;        
      pnl.Controls.Add(btn);
      ViewState["buttonAdded"] = true;
    }
