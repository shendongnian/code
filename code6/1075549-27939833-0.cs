    private async void tb_playername_TextChanged(object sender, EventArgs e)
    {
      var text = (sender as TextBox).Text;
    
      // Check length of the text
      if (string.IsNullOrEmpty(text) || text.Length <= 3)
        return;
    
      // Check timer to not process if user still typing, by measuring the key stoke time
      ...
    
      // Filtering
      List<string> matching_players = await PlayerFilter(text);
    
      // Minimize listbox layout time
      listbox_matchingplayers.SuspendLayout();
      listbox_matchingplayers.DataSource = matching_players;
      listbox_matchingplayers.ResumeLayout();
    }
    
    //Time consuming method
    private async Task<List<string>> PlayerFilter(string text)
    {
      //This method is used to show user the options he can choose with the text he has entered
      
      return matching_players;
    }
