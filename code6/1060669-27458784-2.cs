    // Add 10 buttons dynamically.
    // Bind to the same method.
	for (var i = 1; i <= 10; i += 1)
	{
    	Button btn = new Button();
		btn.Name = "Button" + i;
		btn.Text = "Item " + i;
		this.formLayoutProject.Controls.Add(btn);
		
		// Add handler.
		btn.Click += btn_Click;
	}
