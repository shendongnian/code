    private void redballoon_click(object sender, MouseButtonEventArgs e)
    {
        //react only when baloon is clicked by left mouse button
        if (e.LeftButton != MouseButtonState.Pressed)
            return;
        string red_balloon_question = System.Windows.Browser.HtmlPage.Window.Prompt("Question 5X2");
  
        if (red_balloon_question == "10")
        {
            MessageBox.Show("Well done that is correct, you gain 1 point", "Correct Answer", MessageBoxButton.OK);
            PopBalloonCount++;             
        }
        else
        {
            MessageBox.Show("Incorrect, you loose 1 point", "Wrong Answer", MessageBoxButton.OK);
            PopBalloonCount--;
        }
        score.Content = "Your Score" + " " + Convert.ToString(PopBalloonCount);
        this.lastBalloonClickColor = "red_balloon"; // register the last click
        //hide baloon
        redballoon.Visibility = Visibility.Hidden;
        //or
        redballoon.Opacity = 0.0;
    } 
