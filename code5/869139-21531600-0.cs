    private Action EmptyDelegate = () => { };
    [System.Runtime.CompilerServices.Extension()]
    public void Refresh(UIElement uiElement)
    {
    	uiElement.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
    }
