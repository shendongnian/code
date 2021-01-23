    private void RecentButton_DropDownOpening(object sender, EventArgs e)
    {
      ToolStripDropDownItem RecentButton = (ToolStripDropDownItem)sender;
      RecentButton.DropDown.SuspendLayout();
      try
      {
        RecentButton.DropDownItems.Clear();
        // Populate items
        
        RecentButton.DropDown.MinimumSize = new Size(RecentButton.Bounds.Right - DisplayRectangle.Left, 0);
        RecentButton.DropDown.MaximumSize = RecentButton.DropDown.MinimumSize;
      }
      finally
      {
        RecentButton.DropDown.ResumeLayout();
      }
    }
