    class YourGestureDetector : GestureDetector.SimpleOnGestureListener
        {
            //always return true in OnDown
            public override bool OnDown(MotionEvent e)
            {
                return true;
            }
    
            public override bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
            {
               //detects scrolling motion. return true so it will be picked up by your detector
            }
    
            public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
            {
               //detects "swiping" motion. return true so it will be picked up by your detector
            }
    
        }
