      var hostTool = new ToolStripControlHost(panel) {
        Padding = Padding.Empty,
        Margin = Padding.Empty
      };
      var downButton = new ToolStripDropDownButton("Panel Menu") {
        Alignment = ToolStripItemAlignment.Right,
        DisplayStyle = ToolStripItemDisplayStyle.Text,
        DropDownDirection = ToolStripDropDownDirection.BelowLeft,
      };
      ((ToolStripDropDownMenu)downButton.DropDown).ShowCheckMargin = false;
      ((ToolStripDropDownMenu)downButton.DropDown).ShowImageMargin = false;
      downButton.DropDown.AutoSize = false;
      downButton.DropDown.Size = new Size(panel.Width + 12, panel.Height + 4);
      downButton.DropDown.Items.Add(hostTool);
      var tool = new ToolStrip();
      tool.Items.Add(downButton);
      this.Controls.Add(tool);
