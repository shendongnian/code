    public class StopPage : ContentPage
    {
        public StopPage()
        {
        }
		protected override void OnAppearing()
		{
			App.StartTime = DateTime.Now;
			Content = new StackLayout();
			for (var i = 0; i < 40; i++)
				(Content as StackLayout).Children.Add(new Label{ Text = "Label " + i });
			System.Diagnostics.Debug.WriteLine ((DateTime.Now - App.StartTime).TotalMilliseconds + " ms");
        
            base.OnAppearing();
        }
    }
