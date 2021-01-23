    UserControlQuestion1 question1 = new UserControlQuestion1();
    panel1.Controls.Add(question1);
    question1.Parent.VisibleChanged += new System.EventHandler(question1.Parent_VisibleChanged);
    panel1.Visible = true;
    
