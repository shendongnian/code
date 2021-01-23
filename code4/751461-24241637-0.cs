        protected ScrollViewer InnerScroller;
        private void OnFlipViewerLoaded(object sender, RoutedEventArgs e)
        {
            InnerFlipper = (ScrollViewer)FindChildControl<ScrollViewer>(sender);
            InnerFlipper.ViewChanged += OnPageScroll;
        }
        /// <summary>
        /// Our custom pseudo-infinite collection
        /// </summary>
        ModelCollection ItemsCollection = new ModelCollection();
        private void OnPageScroll(object sender, ScrollViewerViewChangedEventArgs e)
        {
            InnerFlipper.ViewChanged -= OnPageScroll;//Temporarily stop handling this event, to prevent double triggers and let the CPU breath for a little
           int FlipViewerRealIndex = GetFlipViewIndex(sender);
            ItemsCollection.UpdatePages(FlipViewerRealIndex);
            InnerFlipper.ViewChanged += OnPageScroll;//Start getting this event again, ready for the next iteration
        }
        /// <summary>
        /// No idea why, FlipView's inner offset starts at 2. Fuck it, subtract 2 and it works fine.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static int GetFlipViewIndex(object sender)
        {
            double CorrectedScrollOffset= ((ScrollViewer)sender).HorizontalOffset - 2;
            int NewIndex = (int)Math.Round(CorrectedScrollOffset);//Round instead of simple cast, otherwise there is a bias in the direction
            return NewIndex;
        }
