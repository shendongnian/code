    private void ResizeTextbox(TextBox tb, ResizeDirection direction)
    {
        switch (direction) 
        {
             case ResizeDirection.Up:
                  tb.Height += 2;
                  tb.Width += 2;
                  tb.Font = new Font(tb.Font, tb.Font.Size + 1);
                  break;
             case ResizeDirection.Down:
                  tb.Height -= 2;
                  tb.Width -= 2;
                  tb.Font = new Font(tb.Font, tb.Font.Size - 1);
                  break;
        }
    }
    enum ResizeDirection { Up, Down }
