    protected void ShowViewModel<TViewModel>(bool clearbackstack) where TViewModel : MvxViewModel
            {
                if (clearbackstack)
                {
                    var presentationBundle = new MvxBundle(new Dictionary<string, string> { { "MyCustomFlag", "" } });
                    ShowViewModel<TViewModel>(presentationBundle: presentationBundle);
                    return;
                }
            // Normal start
            ShowViewModel<TViewModel>();
        }
