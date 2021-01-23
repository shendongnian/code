    [ImplementPropertyChanged]
    public class NavigatableViewModel
    {
        public NavigatorViewModel Navigator { get; set; }
        public NavigatableViewModel PreviousViewModel { get; set; }
        public NavigatableViewModel NextViewModel { get; set; }
       
    }
