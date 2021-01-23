    List<String> controlNames=new List<String>();
    TextBox txt = new TextBox();
    txt.Name = "TextBox" + v;
    controlNames.Add(txt.Name);
    txt.Location = new Point(30, 5 + (30 * v));
    txt.Tag = btn;
    
    
    TextBox txt1 = new TextBox();
    txt1.Name = "TextBox2" + v;
    controlNames.Add(txt1.Name);
    txt1.Location = new Point(170, 5 + (30 * v));
    txt1.Tag = btn;
