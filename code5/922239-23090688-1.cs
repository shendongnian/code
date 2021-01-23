        private void DisplayCart()
        {
            lstCart.Items.Clear();
            foreach (var movie in cart.Display())
            {
                lstCart.Items.Add(movie);
            }
        }
