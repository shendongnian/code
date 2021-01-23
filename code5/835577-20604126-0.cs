    RectangleF playerRectangle = new RectangleF();
    int COLUMN_WIDTH = 80;
    int ROW_HEIGHT = 60;
    if (playerRectangle.IntersectsWith(wall)){
        int column = playerRectangle.X / COLUMN_WIDTH;
        //----------------------------------------------
        // This will return false if the player 
        // is not positioned right at the column. The 
        // result of % will contain decimal digits.
        // playerRectangle.X has to be a float though.
        //----------------------------------------------
        if(column % 1 == 0){
            //--------------------------------------------
            // do this based on your keyboard logic. this 
            // is pseudo-code
            //--------------------------------------------
            if(keys == keys.UP){
                // Move up
            }
            else if(keys == keys.DOWN){
                // Move down
            }
        }
    }
