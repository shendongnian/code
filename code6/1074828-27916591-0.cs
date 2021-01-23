    public interface IChessPiece {
      bool CheckMove(int row, int col);
    }
    
    // Note "abstract"
    public abstract class ChessPiece: IChessPiece {
      ... 
    
      // Note "abstract"
      public abstract bool CheckMove(int row, int col);
    }
    
    // Pawn implements IChessPiece since it's derived form ChessPiece
    public class Pawn: ChessPiece {
      // Actual implementation
      public override bool CheckMove(int row, int col) { ... }
    }
