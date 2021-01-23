    public string Display()
    {
      CartClass cart = CartClass.GetCart();
      StringBuilder sb = new StringBuilder();
      for ( int i = 0 ; i < cart.CartList.Count() ; i++ )
      {
        Movie movie = cart.CartList[i];
        sb.AppendFormat("{0}.\t{1}\t{2:C}" , i+1 , movie.MovieName , movie.MovieCost ).AppendLine() ;
      }
      return sb.ToString();
    }
