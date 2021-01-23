    public void Clear(Form frm)
    {
      for (int i = 0; i < maxrow; ++i)
      {
        for (int j = 0; j < maxcol; ++j)
        {
          frm.Controls.Remove(MinesBoard[i, j].button);
        }
      }
    }
