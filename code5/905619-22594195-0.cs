    // I've used a string here to match your posted code. However, you would likely
    // be better off with a "BalloonType" enum
    private string lastBalloonClickColor;
    
     private void greenballoon_click(object sender, MouseButtonEventArgs e)
            {
                if (this.lastBalloonClickColor =="red_balloon")
                 { 
                     PopBalloonCount++;
                 }
                else 
                 { 
                     PopBalloonCount--;
                 }
                score.Content = "Your Score" + " " + Convert.ToString(PopBalloonCount);
                this.lastBalloonClickColor = "green_balloon"; // register the last click
            }
     private void redballoon_click(object sender, MouseButtonEventArgs e)
            {
                if (this.lastBalloonClickColor =="green_balloon")
                 { 
                     PopBalloonCount++;
                 }
                else 
                 { 
                     PopBalloonCount--;
                 }
                score.Content = "Your Score" + " " + Convert.ToString(PopBalloonCount);
                this.lastBalloonClickColor = "red_balloon"; // register the last click
            }
