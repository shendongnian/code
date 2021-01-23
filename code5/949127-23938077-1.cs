    Point position = (Point)((Button)sender).Tag;
    int player1CountInThisRow = 0;
    for (var col = 0; col < 3; col++)
    {
       if (((TicTacToeCell)(_button[position.Y, col].Tag).State == CellState.Player1)
       {
             player1CountInThisRow ++;
       }
    }
 
