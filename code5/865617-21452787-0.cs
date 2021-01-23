    public bool OnTouch(View v, MotionEvent e)
       {
           switch (e.Action)
           {
               case MotionEventActions.Down:
                   _viewX = e.GetX();
                   break;
               case MotionEventActions.Move:
                   var left = (int) (e.RawX - _viewX);
                   var right = (int) (left + v.Width);
                   v.Layout(left, v.Top, right, v.Bottom);
                   break;
           }
           return true;
       }
