    <Image TouchDown="UIElement_OnTouchDown"/>
    
     private void UIElement_OnTouchDown(object sender, TouchEventArgs e)
     {
          var touchPoint = e.GetTouchPoint(sender as Image);
          // more processing using touchPoint.Position
     }
