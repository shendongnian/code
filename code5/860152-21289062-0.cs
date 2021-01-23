    private void button1_Click(object sender, EventArgs e) {
      var helpInfo = new StringBuilder();
      helpInfo.AppendLine("This is line one.");
      helpInfo.AppendLine("This is line two.");
      var textHelp = new TextBox() { Multiline = true,
                                     ReadOnly = true,
                                     Text = helpInfo.ToString(),
                                     MinimumSize = new Size(100, 100)
                                    };
      var toolHost = new ToolStripControlHost(textHelp);
      toolHost.Margin = new Padding(0);
      var toolDrop = new ToolStripDropDown();
      toolDrop.Padding = new Padding(0);
      toolDrop.Items.Add(toolHost);
      toolDrop.Show(button1, button1.Width, 0);
    }
