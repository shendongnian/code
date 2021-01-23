    public class StopPage : ContentPage
    {
        public StopPage()
        {
        }
        protected override void OnAppearing()
        {
			System.Diagnostics.Debug.WriteLine ((DateTime.Now - App.StartTime).TotalMilliseconds + " ms");        
            base.OnAppearing();
        }
    }
