    private void DisplayCart()
    {
        lstCart.Items.Clear();
        CartClass CartList = CartClass.GetCart();
        for (int i = 0; i < CartList.CartList.Count(); i++)
        {
            Movies Movie = CartList.CartList[i];
            lstCart.Items.Add(string.Format("{0}.\t{1}\t{2:C}", 
                               i+1, Movie.MovieName, Movie.MovieCost);
        }
    }
