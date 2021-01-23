           //Function scope
           //First section
            if (base.IsPlayer1 == true)
            {
                //If block scope
                Move newMove = moveList.Detect();
            }
            else if (base.IsPlayer1 == false)
            {
                // else if block scope
                MoveKeyboard newMove = moveListKeyboard.DetectMove();
            }
            //Function scope again, newMove is not available.
            //Second section
            if (newMove != null)
            {
                 PlayMove();
            }
