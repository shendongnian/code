    public void LoadTimeline(IEnumerable<MediaTimeline> mediaTimelines)
    {
        // Check that none of the timelines overlap as specified by the
        // acceptance criteria.
        // e.g. timeline2.BeginTime < timeline1.BeginTime + timeline1.Duration.
        _storyboard.Children.Clear();
        
        foreach (MediaTimeline mediaTimeline in mediaTimelines)
        {
            _storyboard.Children.add(mediaTimeline);
        
            MediaElement mediaElement = new MediaElement();
    
            // _grid is just an empty <Grid></Grid> in the xaml layer.
            _grid.Children.Add(mediaElement);
        
            // Each media timeline now targets a dedicated media element.
            Storyboard.SetTarget(mediaTimeline, mediaElement);
        
            // Bring the active media element to the top.
            mediaTimeline.CurrentStateInvalidated += (sender, args)
            {
                Panel.SetZIndex(mediaElement, int.MaxValue);
            };
        }
    }
