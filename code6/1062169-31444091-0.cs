        public delegate void ScrollChangedEventHandler(object sender, EventArgs e);
        public event ScrollChangedEventHandler ScrollChanged;
        public delegate void ScrollReachedBottomEventHandler(object sender, EventArgs e);
        public event ScrollReachedBottomEventHandler ScrollReachedBottom;
        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            base.OnScrollChanged(l, t, oldl, oldt);
            if (ScrollChanged != null)
            {
                ScrollChanged.Invoke(this, new EventArgs());
            }
            // Grab the last child placed in the ScrollView, we need it to determinate the bottom position.
            var view = GetChildAt(ChildCount - 1);
            // Calculate the scrolldiff
            var diff = (view.Bottom - (Height + ScrollY));
            // if diff is zero, then the bottom has been reached
            if (diff == 0 && ScrollReachedBottom != null)
            {
                ScrollReachedBottom.Invoke(this, new EventArgs());
            }
        }
