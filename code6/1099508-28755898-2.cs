    using System.Linq;
    // ...
    nextMove[i] = nextCell;
    listOfNextMoves.Add(new State(nextMove.ToArray()));
    nextMove[i] = Cell.Empty;
