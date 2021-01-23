        class TestAViewModel
        {
          public void ClickEvent()
          {
            TestBViewModel viewModel = new TestBViewModel();
        	viewModel.ShowThisView();
          }
        }
        
        class TestBViewModel
        {
          public void ShowThisView()
          {
             TestBViewModel viewModel = new TestBViewModel();
        	 TestBView view = new TestBView();
        	 view.DataContext = viewModel;
        	 
        	 IDialogService dialogCheckIn = new DialogService();
             dialogCheckIn.ShowTitleDialog(viewModel, view, "Title");
          }
        }
