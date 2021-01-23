    class FocusUIElement : ICommand
    {
        public event EventHandler CanExecuteChanged;
	    public bool CanExecute ( object parameter )
	    {
            return true;
	    }
	    public void Execute ( object parameter )
	    {
            System.Windows.UIElement UIElement = ( System.Windows.UIElement ) parameter;
            UIElement.Focus();
	    }
    }
