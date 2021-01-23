    private void nextDialog_Click(object sender, EventArgs e)
    {
        if (calculate <= 7)
        {
            TextBox text = new TextBox();
            text.Location = new Point(filePathText.Location.X, filePathText.Location.Y + y);
            text.Size = new Size(194, 20);
            text.ReadOnly = true;
            text.Name = "filePathText" + "{calculate}";
            //MessageBox.Show(text.Name);
            this.Controls.Add(text);
            Button button = new Button();
            button.Location = new Point(OpenFileDialogButton.Location.X, OpenFileDialogButton.Location.Y + y);
            button.Size = new Size(33, 24);
            button.Text = "...";
            button.Tag = text.Name;  //Name of associated TextBox added to Tag Property
            button.Click += new EventHandler(OpenFileDialogButton_Click);
            this.Controls.Add(button);
            this.nextDialog.Location = new Point(22, 49 + y);
        }
        else
        {
            this.nextDialog.Controls.Remove(nextDialog);
            this.nextDialog.Dispose();
            MessageBox.Show("Maximální možnost počtů přidaných souborů byla dosažena!");
        }
        y = y + 28;
        calculate++;
    }
