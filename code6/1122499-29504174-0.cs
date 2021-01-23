      listBox1.Items.Clear();
    
      BusinessTier.Business BT = new BusinessTier.Business("netflix.mdf");
    
      if (this.txtMovieID == null) //Hoping this would work and return to the program if I enter a wrong input. 
      {
        listBox1.Items.Add("**Error, this movie ID doesn't exist, or database is empty?!");
        return; // exit out if the MovieID is null
      }
    
