    /// <summary>
        /// How many pages of content should be buffered in each direction
        /// </summary>
        private const int ObservableListRadius = 3;
        /// <summary>
        /// The main update function that replaces placeholder-virtual content with actual content, while freeing up content that's no longe necessary
        /// </summary>
        /// <param name="scrollIndex">The new index absolute index that should be extracted from the Flipview's inner scroller</param>
        public void UpdatePages(int scrollIndex)
        {
            if (scrollIndex < 0 || scrollIndex > Items.Count - 1)
            {
                //If the scroll has move beyond the virtual list, then we're in trouble
                throw new Exception("The scroll has move beyond the virtual list");
            }
            int MinIndex = Math.Max(scrollIndex - ObservableListRadius, 0);
            int MaxIndex = Math.Min(scrollIndex + ObservableListRadius, Items.Count() - 1);
            //Update index content
            (Items.ElementAt(scrollIndex) as ModelPage).UpdatePage(args1);
            Status = Enumerators.CollectionStatusType.FirstPageLoaded;
            //Update increasing radius indexes
            for (int radius = 1; radius <= Constants.ObservableListRadius; radius++)
            {
                if (scrollIndex + radius <= MaxIndex && scrollIndex + radius > MinIndex)
                {
                    (Items.ElementAt(scrollIndex + radius) as ModelPage).UpdatePage(args2);
                }
                if (scrollIndex - radius >= MinIndex && scrollIndex - radius <= MaxIndex)
                {
                    (Items.ElementAt(scrollIndex - radius) as ModelPage).UpdatePage(args3);
                }
            }     
        }
