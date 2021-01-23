    private string MoveForward()
    {
        if (Player.CurrentDirection == "EAST")
        {
            return GetroomEast(); //Once you return the value here it ends the call.
    
            if (Player.NextMove != "") //This line (or anything below it) will never run.
            {
                Player.Y++;
            }
            else
            {
                Console.WriteLine("You Bumped into a Wall");
            }
            //if GetRoomEast is not "", then playercol = playercol+1;
            //if current direction is west...
        }
        //We reach here if Player.CurrentDirection does not equal "EAST"
        //As there is no more code there is no returned value.
        //You would need to do something like return NoValidMove()
    }
