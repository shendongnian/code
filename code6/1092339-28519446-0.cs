      private void browserListView_ItemActivate(object sender, EventArgs e)
      {
         string selectedFile = browserListView.SelectedItems[0].Text;
    
         // If it's a file open it
         if (File.Exists( Path.Combine( currentDir, selectedFile ) ) )
         {
            //MessageBox.Show(currentDir + @"\" + selectedFile);
            try
            {
               System.Diagnostics.Process.Start(currentDir + @"\" + selectedFile);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.StackTrace);
            }
         }
      }
