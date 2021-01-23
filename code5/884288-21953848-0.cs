        Button btn = new Button();
        Controls.Add(btn);
        btn.Tag = "Hello from Button #1";
        btn.Click += btn_Click;
        
        btn = new Button();
        Controls.Add(btn);
        btn.Tag = "Hello from Button #2";
        btn.Click += btn_Click;
