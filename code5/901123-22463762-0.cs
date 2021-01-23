    int tabIndex = 1;
    foreach (string s in new string[] { "D", "E", "F" }) {
      Button b = new Button();
      b.Text = s;
      foreach (Control c in this.Controls) {
        if (c.TabIndex >= tabIndex) {
          c.TabIndex++;
        }
      }
      b.Location = new Point(16, tabIndex * b.Height + 4);
      b.TabIndex = tabIndex++;
      this.Controls.Add(b);
    }
