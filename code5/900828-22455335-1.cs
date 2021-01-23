    class MoveableButton : KinectButton//again, don't know the exact name of this
    {
        private int X, Y;
        private bool selected = false, grabbing = false;
        public void Selected()
        {
            selected = true;
        }
        public void Grabbed()
        {
            grabbing = true;
        }
        public void LetGo()
        {
            grabbing = false;
            selected = false;
        }
        public void Update(UIElement hand)
        {
            if (selected && grabbing)
            {
                this.X = hand.X;
                this.Y = hand.Y;
            }
        }
    }
