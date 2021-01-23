        protected override void OnAppearing()
        {
            BindingContext = controller.Model;
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            BindingContext = null;
            Content = null;
            base.OnDisappearing();
            GC.Collect();
        }
