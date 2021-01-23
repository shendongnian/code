    Label[] l = new Label[6];
    int x = 20;
    for (int i = 0; i < l.Length; i++)
    {
        l[i] = new Label();
        l[i].Name = "Hello " + i.ToString();
        l[i].Text = "Hello " + i.ToString();
        l[i].Location = new Point(x, 10);
        x += 100;
    }
