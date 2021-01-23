    public class StopPage : ContentPage
    {
        public StopPage()
        {
        }
		protected override void OnAppearing()
		{
			App.StartTime = DateTime.Now;
			var layout = new StackLayout();
			for (var i = 0; i < 40; i++)
				layout.Children.Add(new Label{ Text = "Label " + i });
			Content = layout;
			System.Diagnostics.Debug.WriteLine ((DateTime.Now - App.StartTime).TotalMilliseconds + " ms");
        
            base.OnAppearing();
        }
    }
