    object newmove;
    if (base.IsPlayer1 == true)
    {
       newMove = moveList.Detect();
    }
    else
    {
       newMove = moveListKeyboard.DetectMove();
    }
    
    //Second section
    if (newMove != null)
    {
       PlayMove();
    }
