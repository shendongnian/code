    public ViewResult ShowPreviousGuesses()
            {
        GuessingGame theGame = this.Session["GameState"] as GuessingGame;
                    
        return View("Index", theGame.Guesses); 
    }
