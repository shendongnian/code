    string textMessage = "some really long message..."
    int maxWidth = Screen.GetWorkingArea(this).Width - 480;
    int useWidth = Math.Min(TextRenderer.MeasureText(textMessage, 
                            Control.DefaultFont).Width, maxWidth);
    useWidth = Math.Max(useWidth, 640);
    int useHeight = Math.Max(64, TextRenderer.MeasureText(textMessage, 
                                 Control.DefaultFont,
                                 new Size(useWidth, 0), 
                                 TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak)
                                 .Height);
    using (Form f = new Form()) {
      f.Text = "Test Message";
      f.FormBorderStyle = FormBorderStyle.FixedDialog;
      f.MinimizeBox = false;
      f.MaximizeBox = false;
      f.StartPosition = FormStartPosition.CenterScreen;
      f.ClientSize = new Size(useWidth + 8, useHeight + 8);
      Label l = new Label { AutoSize = false };
      l.Text = textMessage;
      l.Font = Control.DefaultFont;
      l.TextAlign = ContentAlignment.MiddleCenter;
      l.Anchor = AnchorStyles.Left | AnchorStyles.Top |
                 AnchorStyles.Right | AnchorStyles.Bottom;
      l.Location = new Point(4, 4);
      l.Size = new Size(f.ClientSize.Width - 8, f.ClientSize.Height - 8);
      f.Controls.Add(l);
      f.ShowDialog(this);
    }
