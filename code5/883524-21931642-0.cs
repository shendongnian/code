            private void LevelUp()
            {
                progressBar1.Maximum = 100; //new experience needed
            }
    
            private void ShowExperience(int xp)
            {
                progressBar1.Value += xp; // Add the xp
            }
