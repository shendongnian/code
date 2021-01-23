      int N = System.Convert.ToInt32(this.txtMovieID.Text);
      BusinessTier.Movie movie = BT.GetMovie(N);
      
      if (movie == null) return; // exit if the GetMovie result is null
    
      BusinessTier.MovieDetail movieid = BT.GetMovieDetail(movie.MovieID); //this part will crash the program if I type a number like 0 or greater than 250 when my database contained 250 rows. 
        
      //display results:
        
      listBox1.Items.Add(movie.MovieName);
    
      foreach (BusinessTier.Review r in movieid.Reviews)
      {
          listBox1.Items.Add(r.UserID + ": " + r.Rating);
      }
