    // assuming you keep a reference of the rectangle
    
    void OnMouseClick(object sender, MouseEventArgs e) {
       if(myRect.Region.IsVisible(e.Location) {
          // perform action on myRect ... 
          // have window Invalidate(myRect)
          // Refresh() the invalidated area.
       }   
    
    }
