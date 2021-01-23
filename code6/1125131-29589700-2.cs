     public void checkAnswer(object sender, CommandEventArgs e)
     {
           ImageButton btn = (ImageButton)sender;
           
           string trueanswer = e.CommandArgument.ToString();
           string urlanswer = e.CommandName.ToString();
           if (urlanswer == q_image)
           {
           }
           else
           {
              // Imagebutoon2 doesnt exist in current context why?
              btn.BorderColor = Color.Red;
           }
      }
