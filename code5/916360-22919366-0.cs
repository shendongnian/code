        PreviewKeyDown += (s, e) =>
        {
          var viewModel = GetActiveViewModel();
          if (e.Key == Key.PageUp)
          {
             viewModel.SelectPreviousItem();
             e.Handled = true;
          }
          else if (e.Key == Key.PageDown)
          {
            viewModel.SelectNextItem();
            e.Handled = true;
          }
        };
