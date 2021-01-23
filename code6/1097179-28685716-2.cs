    List<ChessPiece> pieces = new List<ChessPiece>();
    int mpIndex = -1;     // index of the moving piece
    Rectangle mmr;        // rectangle where moving piece is drawn   
    // board display variables
    int pieceSize = 60; 
    int tileSize = 80;    
    int borderWidth = 50;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        foreach(ChessPiece p in pieces)
        {
            if (!p.onBoard) continue;
            e.Graphics.DrawImage(imageList1.Images[p.pieceIndex], 
                                 borderWidth + p.col * tileSize, 
                                 borderWidth + p.row * tileSize);
                
        }
        if (mpIndex >= 0 && !pieces[mpIndex].onBoard)
            e.Graphics.DrawImage(imageList1.Images[pieces[mpIndex].pieceIndex],
                                 mmr.Location);
    }
