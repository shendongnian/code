    // enum to store panel movement direction
    public enum PanelMovement
    {
        None;
        Left;
        Right;
    }
    
    // member variable to store last panel movement
    private PanelMovement mCurrentMovement = PanelMovement.None;
    
    private void rightLeftForm_KeyDown(object sender, KeyEventArgs e)
    {
            if (e.KeyCode.ToString() == "R")
            {
                // store direction after player has pressed "R"
                mPanelMovement = PanelMovement.Right;
            }
            else if (e.KeyCode.ToString() == "L")
            {
               // store direction after player pressed "L" 
               mPanelMovement = PanelMovement.Left;
            }
            // react on number key pressed
            else if(e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
            {
                if(mPanelMovement == PanelMovement.Left)
                   // move panel left
                else if(mPanelMovement == PanelMovement.Right)
                  // move panel right
            }
        }
