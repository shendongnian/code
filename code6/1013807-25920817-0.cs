        public override bool OnTouchEvent(MotionEvent m_event){
        switch (m_event.Action) {
        case MotionEventActions.Down:
            _viewX = m_event.GetX ();
            System.Console.WriteLine ("Down");
            break;
        case MotionEventActions.Up:
            System.Console.WriteLine ("Up");
            break;
        case MotionEventActions.Move:
            //int x_cord = (int)m_event.GetX;
        //  int y_cord = (int)m_event.GetY;
            System.Console.WriteLine ("Move");
            break;
        }
        return true;
    }
