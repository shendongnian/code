     private void ScanButtonClick(object sender, EventArgs e)
     {
          // do something
          (sender as Button).Enabled = false;
     }
     private void BrowseButtonClick(object sender, EventArgs e)
     {
          ScanButton.Enabled = true;
     }
