    public string Display()
    {
        CartClass CartList = CartClass.GetCart();
        String display = "" ;
    
        for (int i = 0; i < CartList.CartList.Count(); i++)
        {
            Movies Movie = CartList.CartList[i];
            display += String.Format(i + 1 + "." + "\t" + Movie.MovieName + "\t" + "£" + Movie.MovieCost.ToString());
        }
        return display;
    }
