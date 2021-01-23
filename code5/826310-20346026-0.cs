    cmbMovieListingBox.BeginUpdate(); // <- Stop painting
    
    try {
      // Adding new items into the cmbMovieListingBox 
      foreach(var item in LoadListings())
        cmbMovieListingBox.Items.Add(item.GetFilmTitle());
    finally {
      cmbMovieListingBox.EndUpdate(); // <- Finally, repaint if required
    }
