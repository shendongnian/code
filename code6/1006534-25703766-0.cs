    var form = new Form();
    
    var boxes = new TextBox[10];
    for (int i = 0; i < boxes.Length; i++)
    {
        var box = new TextBox();
        box.Location = new Point(10, 30 + 25 * i);
        box.Size = new Size(100, 20);
        form.Controls.Add(box);
    
        boxes[i] = box;
    }
    
    var button = new Button();
    button.Text = "Button";
    button.Click += (o, e) =>
    {
        var message = String.Join(", ", boxes.Select(tb => tb.Text));
        MessageBox.Show(message);
    };
    form.Controls.Add(button);
    
    Application.Run(form);
