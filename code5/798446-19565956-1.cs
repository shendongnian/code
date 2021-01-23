    private void optionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (board != null)
      {
        board.Clear(this);
      }
    
      board = new Board(5, 5, 5);
      this.Size = new Size(board.Column * 25 + 5, board.Row * 25 + 88);
      board.DrawBoard(this);
    }
