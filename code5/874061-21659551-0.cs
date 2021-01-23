        public void CreateCard(Card card)
        {
            CardGUI topCard = new CardGUI(card);
            topCard.Location = new Point(50, 50);
            aPanel.Controls.Add(topCard);
            DrawPlacement(card);
        }
        public void DrawPlacement(Card card)
        {
            CardGUI cardGui = new CardGUI(card);
            cardGui.Location = new Point(a, b);
            a += 18; // Space the cards
            // Put the cards on a new line after half have been laid out.
            counter++;
            if (counter == 26)
            {
                a = 140;
                b = 130;
            }
            this.Update();
            aPanel.Controls.Add(cardGui);
            cardGui.BringToFront();
        }
