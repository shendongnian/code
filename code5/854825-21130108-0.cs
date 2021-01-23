    private void nextDialog_Click(object sender, EventArgs e)
    {
      ...
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
      
      // -- start changes
      button.Click += (o, args) => {
        using (var opf = new OpenFileDialog()) {
          if (opf.ShowDialog() == DialogResult.OK) {
            var souborFilename = opf.FileName;
            text.Text = souborFilename;
          }
        }
      };
      // -- end changes
      this.Controls.Add(button);
      
      this.nextDialog.Location = new Point(22, 49 + y);
      ...
    }
