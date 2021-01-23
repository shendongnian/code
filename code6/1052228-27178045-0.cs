        public void hitPlayer()
        {
            //ilk hit
            if (hitCounter == 0)
            {
                label7.Text = newDeck.Last();
                playerHand[2] = newDeck.Last();
                newDeck = newDeck.Take(newDeck.Count() - 1).ToArray();
                label7.Visible = true;
                pictureBox7.Visible = true;
                **playerTotal** = score(label7, playerTotal);
                aceFound(hitCounter);
                label12.Text = playerTotal.ToString();
            }
        public int score(Label n, int m)
        {
            switch (n.Text)
            {
                case "J": m += 10; break;
                case "Q": m += 10; break;
                case "K": m += 10; break;
                case "A": m += 11; break;
                default: m += Convert.ToInt32(n.Text); break;
            }
            return m;
        }
