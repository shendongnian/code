    TabPage tab = new TabPage(){Text = System.IO.Path.GetFileName(Chosen_File)};
    tabControl1.TabPages.Add(tab);
    tabControl1.SelectedTab = tab;
    RichTextBox rich = new RichTextBox{Parent = tab, Dock = DockStyle.Fill};
    rich.LoadFile(Chosen_File, RichTextBoxStreamType.PlainText);
