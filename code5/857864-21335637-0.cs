    public enum PieceType
    {
        Empty = 0,
        WhitePawn = 1,
        WhiteKnight = 2,
        WhiteBishop = 3,
        WhiteRook = 4,
        WhiteQueen = 5,
        WhiteKing = 6,
        BlackPawn = 7,
        BlackKnight = 8,
        BlackBishop = 9,
        BlackRook = 10,
        BlackQueen = 11,
        BlackKing = 12
    }
    public enum PieceColor
    {
        Unknown = -1,
        Black = 0,
        White = 1
    }
    public enum ContentType
    {
        NotInspected,
        Empty,
        BlockedFriendlyNotMoveable,
        BlockedFriendlyMoveable,
        BlockedCapturable,
    }
	public class Node
    {
        public List<Node> ReachableSquares = new List<Node>();
        public int Square;
        public int RecurseDepth;
        public ContentType Content;
        public Move FreeingMove;
        public Node FreeingMoveNode;
        public Node( int square )
        {
            Square = square;
        }        
    }
	
	[StructLayout( LayoutKind.Explicit )]
    public struct Move
    {
        [FieldOffset( 0 )]
        public MoveBytes b;
        [FieldOffset( 0 )]
        public int u;
    }
	
	public struct MoveBytes
    {
        public int from;
        public int to;
        public PieceType promote;
        public sbyte bits;
    }	
	
	public class FutureMove
    {
        public string Path;
        public int Depth;
        public ContentType Content;
        public string PathIds;
    }
	
    public class ChessBoard
    {
        private PieceType[] _board = new PieceType[ 64 ];
        public ChessBoard()
        {
            for ( int n = 0; n < 64; n++ )
                _board[ n ] = PieceType.Empty;
        }
        public void SetupBoard( KeyValuePair<Int32, PieceType>[] pieces )
        {
            foreach ( var piece in pieces )
                Set( piece.Value, piece.Key );
        }
        public void Set( PieceType pieceType, Int32 square )
        {
            checkSquareThrowExceptionIfInvalid( square );
            _board[ square ] = pieceType;
        }
        public PieceType Get( Int32 square )
        {
            checkSquareThrowExceptionIfInvalid( square );
            return _board[ square ];
        }
        public Boolean Is( PieceType pieceType, Int32 square )
        {
            return Get( square ) == pieceType;
        }
        public ContentType Inspect( int sourceSquare, int targetSquare, out Move move )
        {
            checkSquareThrowExceptionIfInvalid( sourceSquare );
            checkSquareThrowExceptionIfInvalid( targetSquare );
            move = new Move();
            ContentType content = ContentType.NotInspected;
            PieceType pieceOnTargetSquare = _board[ targetSquare ];
            PieceType pieceOnSourceSquare = _board[ sourceSquare ];
            PieceColor pieceColorOnTargetSquare = PieceColor.Unknown;
            PieceColor pieceColorOnSourceSquare = PieceColor.Unknown;
            if ( pieceOnTargetSquare == PieceType.BlackPawn || pieceOnTargetSquare == PieceType.BlackKnight || pieceOnTargetSquare == PieceType.BlackBishop || pieceOnTargetSquare == PieceType.BlackRook || pieceOnTargetSquare == PieceType.BlackQueen || pieceOnTargetSquare == PieceType.BlackKing )
                pieceColorOnTargetSquare = PieceColor.Black;
            else
                pieceColorOnTargetSquare = PieceColor.White;
            if ( pieceOnSourceSquare == PieceType.WhitePawn || pieceOnSourceSquare == PieceType.WhiteKnight || pieceOnSourceSquare == PieceType.WhiteBishop || pieceOnSourceSquare == PieceType.WhiteRook || pieceOnSourceSquare == PieceType.WhiteQueen || pieceOnSourceSquare == PieceType.WhiteKing )
                pieceColorOnSourceSquare = PieceColor.White;
            else
                pieceColorOnSourceSquare = PieceColor.Black;
            switch ( pieceOnTargetSquare )
            {
                case PieceType.Empty:
                    content = ContentType.Empty;
                    break;
                case PieceType.WhitePawn:
                    bool captureLeft = pieceColorOnTargetSquare == PieceColor.Black && Common.File( targetSquare ) > 0 && InspectSquare( targetSquare - 9 ) != PieceType.Empty;
                    bool captureRight = pieceColorOnTargetSquare == PieceColor.Black && Common.File( targetSquare ) < 8 && InspectSquare( targetSquare - 7 ) != PieceType.Empty;
                    bool moveForwardOneSquare = Common.Rank( targetSquare ) != 2 && InspectSquare( targetSquare - 8 ) == PieceType.Empty;
                    bool moveForwardTwoSquares = Common.Rank( targetSquare ) == 2 && InspectSquare( targetSquare - 8 ) == PieceType.Empty;
                    if ( !captureLeft && !captureRight && !moveForwardOneSquare && !moveForwardTwoSquares )
                        content = ContentType.BlockedFriendlyNotMoveable;
                    else
                    {
                        move.b.from = targetSquare;
                        if ( moveForwardTwoSquares )
                            move.b.to = targetSquare - 16;
                        else if ( moveForwardOneSquare )
                            move.b.to = targetSquare - 8;
                        else if ( captureLeft )
                            move.b.to = targetSquare - 9;
                        else if ( captureRight )
                            move.b.to = targetSquare - 7;
                        content = ContentType.BlockedFriendlyMoveable;
                    }
                    break;
                default:
                    if ( ( pieceColorOnSourceSquare == PieceColor.Black && pieceColorOnTargetSquare == PieceColor.White ) || ( pieceColorOnSourceSquare == PieceColor.White && pieceColorOnTargetSquare == PieceColor.Black ) )
                        content = ContentType.BlockedCapturable;
                    break;
            }
            return content;
        }
        public PieceType InspectSquare( int square )
        {
            return _board[ Common.GetMailboxAddress( square ) ];
        }
        public ChessBoard MakeMove( int from, int to )
        {
            ChessBoard newBoard = new ChessBoard();
            for ( int n = 0; n < 64; n++ )
                newBoard.Set( _board[ n ], n );
            newBoard.Set( _board[ from ], to );
            newBoard.Set( PieceType.Empty, from );
            return newBoard;
        }
        public ChessBoard MakeMove( Move move )
        {
            return MakeMove( move.b.from, move.b.to );
        }
        public void DisplayBoard()
        {
            StringBuilder sb = new StringBuilder();
            int rank = 8;
            sb.Append( "+------------------------+" );
            for ( int i = 0; i < 64; i++ )
            {
                if ( ( i & 7 ) == 0 )
                {
                    sb.AppendLine();
                    sb.Append( rank );
                    rank--;
                }
                PieceType piece = Get( i );
                if ( piece == PieceType.Empty )
                {
                    sb.Append( " . " );
                    if ( ( i & 7 ) == 7 )
                    {
                        sb.Append( "|" );
                    }
                    continue;
                }
                switch ( piece )
                {
                    case PieceType.WhitePawn:
                        sb.Append( " P " );
                        break;
                    case PieceType.WhiteKnight:
                        sb.Append( " N " );
                        break;
                    case PieceType.WhiteBishop:
                        sb.Append( " B " );
                        break;
                    case PieceType.WhiteRook:
                        sb.Append( " R " );
                        break;
                    case PieceType.WhiteQueen:
                        sb.Append( " Q " );
                        break;
                    case PieceType.WhiteKing:
                        sb.Append( " K " );
                        break;
                    case PieceType.BlackPawn:
                        sb.Append( " p " );
                        break;
                    case PieceType.BlackKnight:
                        sb.Append( " n " );
                        break;
                    case PieceType.BlackBishop:
                        sb.Append( " b " );
                        break;
                    case PieceType.BlackRook:
                        sb.Append( " r " );
                        break;
                    case PieceType.BlackQueen:
                        sb.Append( " q " );
                        break;
                    case PieceType.BlackKing:
                        sb.Append( " k " );
                        break;
                }
                if ( ( i & 7 ) == 7 )
                {
                    sb.Append( "|" );
                }
            }
            sb.AppendLine();
            sb.Append( "+-a--b--c--d--e--f--g--h-+" );
            Console.WriteLine( sb.ToString() );
        }
        #region Helper functions
        private void checkSquareThrowExceptionIfInvalid( int square )
        {
            if ( square < 0 || square > 63 )
                throw new ArgumentOutOfRangeException( "square" );
        }
        #endregion
    }
	
    public partial class ChessEngine
    {
        private const int PAWN_OFFSET_INDEXOR = 0;
        private const int KNIGHT_OFFSET_INDEXOR = 1;
        private const int BISHOP_OFFSET_INDEXOR = 2;
        private const int ROOK_OFFSET_INDEXOR = 3;
        private const int QUEEN_OFFSET_INDEXOR = 4;
        private const int KING_OFFSET_INDEXOR = 5;
        private const int MAX_RECURSE_DEPTH = 3;
        /* slide, offsets, and offset are basically the vectors that
         * pieces can move in. If slide for the piece is false, it can
         * only move one square in any one direction. offsets is the
         * number of directions it can move in, and offset is an array
         * of the actual directions. */
        private bool[] _slide = new bool[ 6 ] {
	        false, false, true, true, true, false
        };
        private int[] _offsets = new int[ 6 ]  {
	        0, 8, 4, 4, 8, 8
        };
        private int[][] _offset = new int[ 6 ][] {
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, /* pawns */
	        new int[] { -21, -19, -12, -8, 8, 12, 19, 21 },/* knights */
	        new int[] { -11, -9, 9, 11, 0, 0, 0, 0 }, /* bishops */
	        new int[] { -10, -1, 1, 10, 0, 0, 0, 0 }, /* rooks */
	        new int[] { -11, -10, -9, -1, 1, 9, 10, 11 }, /* queen */
	        new int[] { -11, -10, -9, -1, 1, 9, 10, 11 } /* king */
        };
        private Stack<ChessBoard> _boardHistory = new Stack<ChessBoard>();
        public List<FutureMove> Calculate( ChessBoard board, int square )
        {
            Node root = new Node( square );
            root.ReachableSquares = calculateReachableSquares( board, root, 0 );
            foreach ( var node in root.ReachableSquares )
            {
                if ( node.Content != ContentType.Empty )
                    continue;
                _boardHistory.Push( board );
                var tempBoard = board.MakeMove( root.Square, node.Square );
                var allReachableSquares = calculateReachableSquares( tempBoard, node, 1 );
                node.ReachableSquares = RemoveDuplicateSquares( allReachableSquares, root.ReachableSquares );
                foreach ( var innerNode in node.ReachableSquares )
                {
                    if ( innerNode.Content != ContentType.Empty )
                        continue;
                    _boardHistory.Push( tempBoard );
                    tempBoard = tempBoard.MakeMove( node.Square, innerNode.Square );
                    allReachableSquares = calculateReachableSquares( tempBoard, innerNode, 2 );
                    innerNode.ReachableSquares = RemoveDuplicateSquares( allReachableSquares, node.ReachableSquares, root.ReachableSquares );
                    tempBoard = _boardHistory.Pop();
                }
                board = _boardHistory.Pop();
            }
            checkBoardHistoryEmptyThrowExceptionIfNot();
            return getFutureMoves( root );
        }
        private List<Node> calculateReachableSquares( ChessBoard board, Node node, int recurseDepth )
        {
            if ( recurseDepth > MAX_RECURSE_DEPTH )
                return null;
            int indexor = -1;
            switch ( board.Get( node.Square ) )
            {
                case PieceType.WhiteBishop:
                case PieceType.BlackBishop:
                    indexor = BISHOP_OFFSET_INDEXOR;
                    break;
            }
            bool takeBackMove = false;
            if ( indexor >= 0 )
            {
                for ( int j = 0; j < _offsets[ indexor ]; ++j )
                {
                    for ( int n = node.Square; ; )
                    {
                        int oset = _offset[ indexor ][ j ];
                        n = Common.GetMailboxAddress( n, oset );
                        if ( n == -1 )
                            break;
                        Move move;
                        ContentType pieceOnSquare = board.Inspect( node.Square, n, out move );
                        if ( pieceOnSquare == ContentType.NotInspected )
                            throw new Exception( String.Format( "Unable to inspect square {0}", n ) );
                        Node newNode = new Node( n ) { Content = pieceOnSquare, RecurseDepth = recurseDepth + 1 };
                        if ( move.u > 0 )
                            newNode.FreeingMove = move;
                        node.ReachableSquares.Add( newNode );
                        // Do we need to move the piece out of the way?
                        if ( pieceOnSquare == ContentType.BlockedFriendlyMoveable && newNode.RecurseDepth < 3 )
                        {
                            // Yes, we do.
                            recurseDepth++;
                            // Put the current board on the stack to preserve state.
                            _boardHistory.Push( board );
                            // Make the move.
                            board = board.MakeMove( move );
                            pieceOnSquare = board.Inspect( node.Square, n, out move );
                            var freeingMoveNode = new Node( n ) { Content = pieceOnSquare, RecurseDepth = recurseDepth + 1 };
                            if ( move.u > 0 )
                                freeingMoveNode.FreeingMove = move;
                            freeingMoveNode.FreeingMoveNode = newNode;
                            node.ReachableSquares.Add( freeingMoveNode );
                            // Lets the method know we need to put the board back.
                            takeBackMove = true;
                        }
                        else if ( pieceOnSquare != ContentType.Empty )
                            break;
                    }
                    // Reverts to a previous board state.
                    if ( takeBackMove )
                    {
                        recurseDepth--;
                        takeBackMove = false;
                        board = _boardHistory.Pop();
                    }
                }
            }
            return node.ReachableSquares;
        }
        /// <summary>
        ///  Compares <paramref name="firstList"/> with <paramref name="secondList"/> and
        ///  returns a list of squares that exist in both lists.
        /// </summary>
        static IEnumerable<int> Intersect( List<Node> firstList, List<Node> secondList )
        {
            return firstList.Select( a => a.Square )
                .Intersect( secondList.Select( a => a.Square ) )
                .ToList();
        }
        /// <summary>
        ///  Combines <paramref name="firstList"/> and <paramref name="secondList"/> to make a single list before 
        ///  comparing the combined list with <paramref name="thirdList"/> returning a list of squares that in the 
        ///  two lists.
        /// </summary>
        private IEnumerable<int> Intersect( List<Node> firstList, List<Node> secondList, List<Node> thirdList )
        {
            return firstList.Select( a => a.Square )
                .Union( thirdList.Select( a => a.Square ) )
                .Intersect( secondList.Union( firstList ).Select( a => a.Square ) )
                .ToList();
        }
        /// <summary>
        ///  Looks for duplicates squares in <paramref name="originalList"/> and returns a new
        ///  List without these duplicates.
        /// </summary>
        private List<Node> RemoveDuplicateSquares( List<Node> originalList, List<Node> comparerList )
        {
            List<Node> newList = originalList.ToList();
            IEnumerable<Int32> dups = Intersect( newList, comparerList );
            newList.RemoveAll( a => dups.Contains( a.Square ) );
            return newList;
        }
        /// <summary>
        ///  Looks for duplicates squares in <paramref name="originalList"/> and returns a new
        ///  List without these duplicates.
        /// </summary>
        private List<Node> RemoveDuplicateSquares( List<Node> originalList, List<Node> comparerList1, List<Node> comparerList2 )
        {
            List<Node> newList = originalList.ToList();
            IEnumerable<Int32> dups = Intersect( comparerList1, comparerList2, newList );
            newList.RemoveAll( a => dups.Contains( a.Square ) );
            return newList;
        }
        private void checkBoardHistoryEmptyThrowExceptionIfNot()
        {
            // Must ensure the board history is empty before exiting.
            if ( _boardHistory.Count > 0 )
                throw new Exception( "Board stack not empty." );
        }
        private List<FutureMove> getFutureMoves( Node node )
        {
            return getFutureMoves( node, null, null );
        }
        private List<FutureMove> getFutureMoves( Node node, String path, String pathIds )
        {
            List<FutureMove> rows = new List<FutureMove>();
            StringBuilder currentPath = new StringBuilder();
            StringBuilder currentPathIds = new StringBuilder();
            if ( path != null )
                currentPath.AppendFormat( "{0}", path );
            else
                currentPath.AppendFormat( "{0}", Common.ConvertToBoardPosition( node.Square ) );
            if ( pathIds != null )
                currentPathIds.AppendFormat( "{0}", pathIds );
            else
                currentPathIds.AppendFormat( "{0}", node.Square );
            foreach ( var n in node.ReachableSquares )
            {
                string temp = String.Format( "{0}-{1}", currentPath, Common.ConvertToBoardPosition( n.Square ) );
                string tempPathIds = String.Format( "{0}-{1}", currentPathIds, n.Square );
                if ( n.ReachableSquares.Any() )
                {
                    rows.AddRange( getFutureMoves( n, temp, tempPathIds ) );
                }
                FutureMove fm = new FutureMove();
                fm.Depth = n.RecurseDepth;
                fm.Path = temp.ToString();
                fm.PathIds = tempPathIds;
                fm.Content = n.Content;
                rows.Add( fm );
            }
            return rows;
        }
    }
    public static class Common
    {
        static int[] _mailbox = new int[ 120 ]  {
	        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
	        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
	        -1,  0,  1,  2,  3,  4,  5,  6,  7, -1,
	        -1,  8,  9, 10, 11, 12, 13, 14, 15, -1,
	        -1, 16, 17, 18, 19, 20, 21, 22, 23, -1,
	        -1, 24, 25, 26, 27, 28, 29, 30, 31, -1,
	        -1, 32, 33, 34, 35, 36, 37, 38, 39, -1,
	        -1, 40, 41, 42, 43, 44, 45, 46, 47, -1,
	        -1, 48, 49, 50, 51, 52, 53, 54, 55, -1,
	        -1, 56, 57, 58, 59, 60, 61, 62, 63, -1,
	        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
	        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
        static int[] _mailbox64 = new int[ 64 ] {
	        21, 22, 23, 24, 25, 26, 27, 28,
	        31, 32, 33, 34, 35, 36, 37, 38,
	        41, 42, 43, 44, 45, 46, 47, 48,
	        51, 52, 53, 54, 55, 56, 57, 58,
	        61, 62, 63, 64, 65, 66, 67, 68,
	        71, 72, 73, 74, 75, 76, 77, 78,
	        81, 82, 83, 84, 85, 86, 87, 88,
	        91, 92, 93, 94, 95, 96, 97, 98
        };
        public static int GetMailboxAddress( int square )
        {
            return _mailbox[ _mailbox64[ square ] ];
        }
        public static int GetMailboxAddress( int square, int offset )
        {
            return _mailbox[ _mailbox64[ square ] + offset ];
        }
        public static string ConvertToBoardPosition( int from, int to )
        {
            string a = Convert.ToChar( 97 + File( from ) ) + Convert.ToString( Rank( from ) );
            string b = Convert.ToChar( 97 + File( to ) ) + Convert.ToString( Rank( to ) );
            return a + '-' + b;
        }
        public static string ConvertToBoardPosition( int square )
        {
            string a = Convert.ToChar( 97 + File( square ) ) + Convert.ToString( Rank( square ) );
            return a;
        }
        public static int File( int x )
        {
            return ( x & 7 );
        }
        public static int Rank( int x )
        {
            return 8 - ( x >> 3 );
        }
        public static string ContentTypeValueToString( ContentType contentTypeEnumValue )
        {
            string contentTypeStr = string.Empty;
            switch ( contentTypeEnumValue )
            {
                case ContentType.BlockedCapturable:
                    contentTypeStr = "Blocked, Capturable";
                    break;
                case ContentType.BlockedFriendlyMoveable:
                    contentTypeStr = "Blocked, Friendly, Moveable";
                    break;
                case ContentType.BlockedFriendlyNotMoveable:
                    contentTypeStr = "Blocked, Friendly, Not Moveable";
                    break;
                case ContentType.Empty:
                    contentTypeStr = "Empty";
                    break;
                default:
                    contentTypeStr = "Error!";
                    break;
            }
            return contentTypeStr;
        }
    }
	
	// Main calling program	
    class Program
    {
        static void Main( string[] args )
        {
            ChessBoard cb = new ChessBoard();
            cb.SetupBoard( new KeyValuePair<Int32, PieceType>[] 
            { 
                // Setup Black pieces
                new KeyValuePair<Int32, PieceType>( 3, PieceType.BlackRook ),
                new KeyValuePair<Int32, PieceType>( 5, PieceType.BlackKing ), 
                new KeyValuePair<Int32, PieceType>( 11, PieceType.BlackKnight ), 
                new KeyValuePair<Int32, PieceType>( 12, PieceType.BlackKnight ), 
                new KeyValuePair<Int32, PieceType>( 13, PieceType.BlackPawn ), 
                new KeyValuePair<Int32, PieceType>( 14, PieceType.BlackPawn ), 
                new KeyValuePair<Int32, PieceType>( 16, PieceType.BlackQueen ), 
                new KeyValuePair<Int32, PieceType>( 17, PieceType.BlackPawn ), 
                new KeyValuePair<Int32, PieceType>( 18, PieceType.BlackPawn ), 
                new KeyValuePair<Int32, PieceType>( 19, PieceType.BlackRook ), 
                new KeyValuePair<Int32, PieceType>( 23, PieceType.BlackPawn ), 
                new KeyValuePair<Int32, PieceType>( 24, PieceType.BlackPawn ), 
                // Setup White pieces
                new KeyValuePair<Int32, PieceType>( 31, PieceType.WhitePawn ), 
                new KeyValuePair<Int32, PieceType>( 32, PieceType.WhitePawn ), 
                new KeyValuePair<Int32, PieceType>( 35, PieceType.WhitePawn ), 
                new KeyValuePair<Int32, PieceType>( 36, PieceType.WhitePawn ), 
                new KeyValuePair<Int32, PieceType>( 37, PieceType.WhitePawn ), 
                new KeyValuePair<Int32, PieceType>( 38, PieceType.WhitePawn ), 
                new KeyValuePair<Int32, PieceType>( 40, PieceType.WhiteKnight ), 
                new KeyValuePair<Int32, PieceType>( 41, PieceType.WhiteBishop ), 
                new KeyValuePair<Int32, PieceType>( 42, PieceType.WhiteRook ),
                new KeyValuePair<Int32, PieceType>( 53, PieceType.WhiteKing )
            }
            );
            cb.DisplayBoard();
            int square = 41;
            ChessEngine eng = new ChessEngine();
            List<FutureMove> futureMoves = eng.Calculate( cb, square );
            int move1 = futureMoves.Where( m => m.Depth == 1 ).Count();
            int move2 = futureMoves.Where( m => m.Depth == 2 ).Count();
            int move3 = futureMoves.Where( m => m.Depth == 3 ).Count();
            Console.WriteLine();
            Console.WriteLine( String.Format( "Number of potential squares reached in 1 move  {0,3} from square {1,2}", move1, square ) );
            Console.WriteLine( String.Format( "Number of potential squares reached in 2 moves {0,3} from square {1,2}", move2, square ) );
            Console.WriteLine( String.Format( "Number of potential squares reached in 3 moves {0,3} from square {1,2}", move3, square ) );
            //dumpMoves( node );
            Console.WriteLine();
            Console.WriteLine( "Press any key to exit." );
            Console.ReadKey();
        }
        static ArrayList dumpMovesRecursive( Node node, String path )
        {
            ArrayList rows = new ArrayList();
            StringBuilder currentPath = new StringBuilder();
            if ( path != null )
                currentPath.AppendFormat( "{0}", path );
            else
                currentPath.AppendFormat( "{0}", Common.ConvertToBoardPosition( node.Square ) );
            foreach ( var n in node.ReachableSquares )
            {
                string temp = String.Format( "{0}-{1}", currentPath, Common.ConvertToBoardPosition( n.Square ) );
                if ( n.ReachableSquares.Any() )
                {
                    rows.AddRange( dumpMovesRecursive( n, temp ) );
                }
                StringBuilder content = new StringBuilder();
                content.Append( Common.ContentTypeValueToString( n.Content ) );
                if ( n.FreeingMoveNode != null )
                {
                    content.AppendFormat( " after move {0}", n.FreeingMoveNode.FreeingMove.b );
                }
                StringBuilder str = new StringBuilder();
                str.AppendFormat( "| {0,-12} | {1,-32} |", temp.ToString(), content );
                rows.Add( str.ToString() );
            }
            return rows;
        }
    }
