            private int CurrentSectionIndex = 0;
            private HubSection CurrentSection
            {
                get { return this.Hub.SectionsInView[CurrentSectionIndex]; }
            }
            //Retrieve the ScrollViewer of the Hub control and handle the ViewChanged event of this ScrollViewer
            public Page()
            {
                ScrollViewer sv = ControlHelper.GetChild<ScrollViewer>(this.Hub);
                sv.ViewChanged += sv_ViewChanged;
            }
            //In the ViewChanged event handler body then calculate the index relative to the horizontal offset (means current position) of the ScrollViewer
            void sv_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
            {
                if(!e.IsIntermediate)
                {
                    double ho = ControlHelper.GetChild<ScrollViewer>(this.Hub).HorizontalOffset;
    
                    if (ho >= CurrentSection.ActualWidth - (this.ActualWidth - CurrentSection.ActualWidth))
                    {
                        CurrentSectionIndex = (int)((ho + (this.ActualWidth - CurrentSection.ActualWidth)) / CurrentSection.ActualWidth);
                    }
                }
            }
