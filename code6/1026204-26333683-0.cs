    CheckBox box;
    for (int i = 0; i < yourList.Count; i++)
    {
        box = new CheckBox();
        box.Tag = yourList[i];
        box.Text = yourList[i].ToString();
        box.AutoSize = true;
        box.Location = new Point(10, i * 50); //vertical
        //box.Location = new Point(i * 50, 10); //horizontal
        this.Controls.Add(box);
    }
