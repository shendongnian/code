        private void HideControls()
        {
            this.HideAnimation.Begin();
            Window.Current.CoreWindow.PointerCursor = null;
        }
        private void ShowControls()
        {
            this.ShowAnimation.Begin();
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Arrow, 1);
        }
