    CheckBox[] checkBoxArray = new CheckBox[lines.Count()];
    int yLocation = 25;
    int diff = 0;
    int i = 0;
    foreach(var line in lines)
    {
        CheckBox checkBox = new CheckBox();
        checkBox.Text = line;
        checkBox.Location = new System.Drawing.Point(90, yLocation + diff);
        checkBox.Size = new System.Drawing.Size(110, 30);
        checkBoxArray[i] = checkBox;
        i++;
        diff = diff + 30;
        Controls.Add(checkBox);  // Add checkbox to form
    }
