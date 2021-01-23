    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                pictureBox1.MouseDown += pictureBox1_MouseDown;
            }
    
            #region Properties
    
            private Board Board { get; set; }
            private Piece CurrentPiece { get; set; }
            private Dictionary<Piece, Bitmap> PieceBitmaps { get; set; }
            private int TileWidth { get; set; }
            private int TileHeight { get; set; }
    
            #endregion
    
            #region Events
    
            private void Form1_Load(object sender, EventArgs e)
            {
                InitializeGame();
                DrawGame();
            }
    
            private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
            {
                PickOrDropPiece(e);
                DrawGame();
            }
    
            #endregion
    
            #region Methods
    
            private void InitializeGame()
            {
                TileWidth = 64;
                TileHeight = 64;
    
                Board = new Board();
    
                PieceBitmaps = new Dictionary<Piece, Bitmap>();
                PieceBitmaps.Add(new Piece(PieceType.Pawn, PieceColor.Black), new Bitmap("pawnblack.png"));
                PieceBitmaps.Add(new Piece(PieceType.Pawn, PieceColor.White), new Bitmap("pawnwhite.png"));
            }
    
            private void DrawGame()
            {
                var tileSize = new Size(TileWidth, TileHeight);
                Bitmap bitmap = CreateBoard(tileSize);
                DrawPieces(bitmap);
                pictureBox1.Image = bitmap;
            }
    
            private Bitmap CreateBoard(Size tileSize)
            {
                int tileWidth = tileSize.Width;
                int tileHeight = tileSize.Height;
                var bitmap = new Bitmap(tileWidth*8, tileHeight*8);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            Brush brush = (x%2 == 0 && y%2 == 0) || (x%2 != 0 && y%2 != 0) ? Brushes.Black : Brushes.White;
                            graphics.FillRectangle(brush, new Rectangle(x*tileWidth, y*tileHeight, tileWidth, tileHeight));
                        }
                    }
                }
                return bitmap;
            }
    
            private void DrawPieces(Bitmap bitmap)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Board board = Board;
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            Piece piece = board.GetPiece(x, y);
                            if (piece != null)
                            {
                                Bitmap bitmap1 = PieceBitmaps[piece];
    
                                graphics.DrawImageUnscaled(bitmap1, new Point(x*TileWidth, y*TileHeight));
                            }
                        }
                    }
                }
            }
    
            private void PickOrDropPiece(MouseEventArgs e)
            {
                Point location = e.Location;
                int x = location.X/TileWidth;
                int y = location.Y/TileHeight;
                bool pickOrDrop = CurrentPiece == null;
                if (pickOrDrop)
                {
                    // Pick a piece
                    Piece piece = Board.GetPiece(x, y);
                    Board.SetPiece(x, y, null);
                    if (piece != null)
                    {
                        label1.Text = string.Format("You picked a {0} {1} at location {2},{3}", piece.Color, piece.Type, x,
                            y);
                    }
                    else
                    {
                        label1.Text = "Nothing there !";
                    }
                    CurrentPiece = piece;
                }
                else
                {
                    // Drop picked piece
                    Board.SetPiece(x, y, CurrentPiece);
                    label1.Text = string.Format("You dropped a {0} {1} at location {2},{3}", CurrentPiece.Color,
                        CurrentPiece.Type, x,
                        y);
                    CurrentPiece = null;
                }
            }
    
            #endregion
        }
    
        public class Board
        {
            private readonly Piece[] _pieces;
    
            public Board()
            {
                _pieces = new Piece[8*8];
                PopulatePieces();
            }
    
            public Piece GetPiece(int x, int y)
            {
                int i = y*8 + x;
                return _pieces[i];
            }
    
            public void SetPiece(int x, int y, Piece piece)
            {
                int i = y*8 + x;
                _pieces[i] = piece;
            }
    
            private void PopulatePieces()
            {
                for (int i = 0; i < 8; i++)
                {
                    SetPiece(i, 1, new Piece(PieceType.Pawn, PieceColor.Black));
                    SetPiece(i, 7, new Piece(PieceType.Pawn, PieceColor.White));
                }
            }
        }
    
        public class Piece
        {
            private readonly PieceColor _color;
            private readonly PieceType _type;
    
            public Piece(PieceType type, PieceColor color)
            {
                _type = type;
                _color = color;
            }
    
            public PieceType Type
            {
                get { return _type; }
            }
    
            public PieceColor Color
            {
                get { return _color; }
            }
    
            protected bool Equals(Piece other)
            {
                return _color == other._color && _type == other._type;
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((Piece) obj);
            }
    
            public override int GetHashCode()
            {
                unchecked
                {
                    return ((int) _color*397) ^ (int) _type;
                }
            }
    
            public static bool operator ==(Piece left, Piece right)
            {
                return Equals(left, right);
            }
    
            public static bool operator !=(Piece left, Piece right)
            {
                return !Equals(left, right);
            }
        }
    
        public enum PieceType
        {
            Pawn
        }
    
        public enum PieceColor
        {
            Black,
            White
        }
    }
