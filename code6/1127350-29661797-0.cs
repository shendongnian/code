    static void Main(string[] args)
            {
                if (((FrameworkElement)e.OriginalSource).DataContext != null)
                {
                    IMyViewModel viewModel = ((FrameworkElement)e.OriginalSource).DataContext as IMyViewModel;
    
                    if (viewModel != null)
                    {
                        viewModel.MyCommand.Execute(viewModel);
                    }
                }
            }
