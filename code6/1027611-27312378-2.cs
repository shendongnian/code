    public sealed partial class DetailsPage : Page {
        // ... 
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            var parameter = e.Parameter as string;  // "My data"
            base.OnNavigatedTo(e);
        }
    }
