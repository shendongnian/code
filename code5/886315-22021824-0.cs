    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SO_22015528
    {
      class Program
      {
        static void Main( string[] args )
        {
          // test code
          ChessPiece a2 = new ChessPiece( ePieceType.Queen, 900, 48 );
          ChessPiece b3 = new ChessPiece( ePieceType.Bishop, 375, 41 );
          ChessPiece f1 = new ChessPiece( ePieceType.Rook, 500, 61 );
          ChessPiece f2 = new ChessPiece( ePieceType.Rook, 500, 53 );
    
          // This just simulates pieces that attack on the f7 square.
          List<Constraint> f7 = new List<Constraint>();
          f7.Add( new Constraint( b3, eRayDirection.NorthEast ) );
          f7.Add( new Constraint( a2, eRayDirection.NorthEast ) );
          f7.Add( new Constraint( f1, eRayDirection.North ) );
          f7.Add( new Constraint( f2, eRayDirection.North ) );
    
          // Get all positive ray directions ( use to simplify LINQ orderby )
          List<eRayDirection> positiveRayDirections = new List<eRayDirection>();
          positiveRayDirections.Add( eRayDirection.North );
          positiveRayDirections.Add( eRayDirection.NorthEast );
          positiveRayDirections.Add( eRayDirection.NorthWest );
          positiveRayDirections.Add( eRayDirection.West );
    
          var groups = f7
            .GroupBy( g => g.Ray )
            .Select( a =>
            new
            {
              Key = a.Key,
              Results = positiveRayDirections.Contains( a.Key ) ? a.OrderBy( x => x.Piece.XY ).ToList() : a.OrderByDescending( x => x.Piece.XY ).ToList()
            } ).ToList();
    
                  // The groups object returns two discrete groups here; 
                  // NorthEast containing 2 entries (Bishop & Queen) and North 
                  // also containing to entries (Rook x 2).
          List<Constraint> attackOrder = groups.SelectMany(x => x.Results).OrderByDescending(x => x.Piece.Value).ToList();
    
          foreach ( var ao in attackOrder )
              Console.WriteLine( ao.ToString() );
    
          Console.ReadKey();
        }
      }
    }
