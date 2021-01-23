        public IEnumerable<string> Display()
        {
            CartClass CartList = CartClass.GetCart();
            for (int i = 0; i < CartList.CartList.Count(); i++)
            {
                Movies Movie = CartList.CartList[i];
                yield return String.Format(i + 1 + "." + "\t" 
                    + Movie.MovieName + "\t" + "£" + Movie.MovieCost.ToString() + "\n" );
            }
        }
