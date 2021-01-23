        private void button1_Click(object sender, EventArgs e)
        {
            int number = int number = choice(0, 2);
            Move opponentMove = (Move) number;
            if (CurrentlySelectedMove == opponentMove)
            {
                MessageBox.Show("Draw !");  
            }
            else if ((CurrentlySelectedMove == Move.Rock && opponentMove == Move.Paper) ||
                    (CurrentlySelectedMove == Move.Paper && opponentMove == Move.Scissors) ||
                    (CurrentlySelectedMove == Move.Scissors && opponentMove == Move.Rock))
            {
                MessageBox.Show("You loose !");  
            }
            else
            {
                MessageBox.Show("You win !");     
            }
        }
