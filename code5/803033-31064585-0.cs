     private void gameStart_Click(object sender, EventArgs e)
        {
            string machineName = System.Environment.MachineName;
            int numberOfPlayers = 10;
            multiplayerGame y = new multiplayerGame(numberOfPlayers, machineName);// multiplayerGame is the next form, and y is just a very simple variable the new form plus variables that are being passed is assigned to
                    this.Hide();();// hides this (current) form
                    y.ShowDialog();//here is where the variable y is used with .ShowDialog to make your program open the new form
            }
        }
