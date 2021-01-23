    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < CartList.CartList.Count(); i++)
        {
            Movies Movie = CartList.CartList[i];
            sb .Append(String.Format(i + 1 + "." + "\t" + Movie.MovieName + "\t" + "£" + Movie.MovieCost.ToString());
        }
        return sb.ToString();
