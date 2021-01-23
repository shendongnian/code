    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var storyboard = VisualStateManager.GetVisualStateGroups(this.grid).Get("ShowHideHelp").States.Get("ShowHelp").Storyboard;
        ((DoubleAnimation)(storyboard.Children[0])).To = 500;
    }
    
    public static class VisualStateExtensions
    {
        public static VisualStateGroup Get(this IList<VisualStateGroup> stateGroups, string name)
        {
            return stateGroups.Single(x => x.Name == name);
        }
    
        public static VisualState Get(this IList<VisualState> stateGroups, string name)
        {
            return stateGroups.Single(x => x.Name == name);
        }
    }
