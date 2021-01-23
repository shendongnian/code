    Storyboard storyboard = (Storyboard)this.Resources["TheStoryboard"];
    
    private void BeginStoryBoard()
    {
      storyboard.begin(this, true);
    }
    
    private void SetStoryBoardActivity(bool play)
    {
      if (play)
      {
        storyboard.Resume(this);
      }
      else
      {
        storyboard.Pause(this);       
      }
    }
