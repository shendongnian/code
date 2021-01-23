        private void DrawSplitBar(int mode)
        {
          ...
          if (mode != DRAW_END)
          {
            var rect = newRect;
            SubtractRect(out newRect, ref newRect, ref oldRect);
            SubtractRect(out oldRect, ref oldRect, ref rect);
          }
          DrawSplitHelper(oldRect);
          ...
  
