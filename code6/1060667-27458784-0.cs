    Button btn = new Button();
    btn.Name = "Button1";
    btn.Text = "Item 1";
    this.formLayoutProject.Controls.Add(btn);
    
    // Add handler.
    btn.Click += btn_Click;
