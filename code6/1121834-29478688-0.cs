    CheckBox chk = new CheckBox();
    chk.AutoSize = true;
    chk.Text = new DirectoryInfo(folder).Name;
    chk.Location = new Point(10, i * 25);
    panelSubfolders.Controls.Add(chk);          
    i++;
