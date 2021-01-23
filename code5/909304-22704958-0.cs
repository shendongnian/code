    IsolatedStorageSettings highScoreSettings = IsolatedStorageSettings.ApplicationSettings;
      public void TimeLeftTick(Object sender, EventArgs args)
            {
                prog1.Value-=10;
                  //GAME ENDS
                if (prog1.Value == 0)
                {
                    //If there is already a highscore saved 
                    if(highScoreSettings.Contains("highscore"))
                    if (Score > Convert.ToInt32(highScoreValue.Text))
                    { 
    
                        highScoreSettings.Remove("highscore"); // remove highscore
                        highScoreSettings.Add("highscore", Score.ToString()); 
                        highScoreSettings.Save();
                        highScoreValue.Text = highScoreSettings["highscore"].ToString(); 
                    }
                    MessageBox.Show("Time is out");
                    TimeLeft.Stop();
                    prog1.Value = 100;
                    return;
                }
