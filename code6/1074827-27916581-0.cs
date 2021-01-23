    public class ChessPiece : IChessPiece { ... }
    
    public class Pawn : ChessPiece, IChessPiece
    {
         public bool CheckMove(int row, int col) { ... }
    }
    
    public class ChessPieces {  public List<IChessPieces> chessPieces; ... }
