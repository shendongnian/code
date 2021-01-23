        private void raceButton_Click(object sender, EventArgs e)
        {
            bool winner = false;
            int winningDog = 0;
            for (int eachDog = 0; eachDog < Dogs.Length; eachDog++)
            {
                Dogs[eachDog].TakeStartingPosition();
            }
            Application.DoEvents();
            while (!winner)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Dogs[i].Run())
                    {
                        winner = true;
                        winningDog = i+1;
                    }
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }
            }
            MessageBox.Show("Winning Dog is #" + winningDog);
        }
