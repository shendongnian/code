    Panel parent = new Panel();
    parent.BackColor = Color.Red;
    parent.Location = new Point(20, 25);
    Controls.Add(parent);
    Panel child = new Panel();
    child.Parent = parent;
    child.BackColor = Color.Blue;
    child.Location = new Point(5, 5);
