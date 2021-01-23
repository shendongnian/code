       void TouchFrameReported(object sender, TouchFrameEventArgs e)
        {
          var tp = e.GetPrimaryTouchPoint(Control); // Control you want to manupulate
            switch (tp.Action)
            {
                    case TouchAction.Move:
                    case  TouchAction.Up:
                    case  TouchAction.Down:
             }
          }
