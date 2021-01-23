    OnKeyDown(object sender, EventArgs e){
       MyLogic(e.KeyCode); //I can remember but this is the idea
       myControlBoard.Invalidate();
    }
    OnPaint(object sender, EventArgs e){
     for(int i = 0; i < mybox.GetLenght(0); i ++)
      for(int j = 0; j < mybox.GetLenght(1); j++)
      { 
         DrawBox(i, j)
      }
    }
