    bool isClicked = false;
        public bool IsClicked
        {
            get
            {
                return isClicked;
            }
            set
            {
                isClicked = value;
                if (value) BackColor = Color.Green;
                else BackColor = Color.Blue;
            }
        }
