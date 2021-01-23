    public class Ball
    {
        public bool colliding = false;
    }
    //In Update of Ball/Game
    bool player1Collision = ballrec.Intersects(player1rec)
        && ball.x <= 20
        && ball.y >= player.y
        && ball.y + 20 <= player.y + 100;
    if( player1Collision && !ball.colliding )
    {
        // Set state here, so reduce issues when there is a chance that different players can overlap
        ball.colliding = true;
        // .....
    }
    // Same for player 2,3,4,5 .....
    //Update state for next frame
    ball.colliding = player1Collision || player2Collision /* .... */;
