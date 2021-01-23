    private void MouseLeaveEvent(object sender, EventArgs e)
      {
         Button b = sender as Button;
         if(b != null)
         { 
              string id = b.Id;
              //Do Something with _dict[id].MouseLeaveImage
         }
      }
    
      private void MouseEnterEvent(object sender, EventArgs e)
      {
         Button b = sender as Button;
         if(b != null)
         { 
              string id = b.Id;
              //Do Something with _dict[id].MouseEnterImage
         }
      }
