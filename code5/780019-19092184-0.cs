    class ViewService : IViewService
    {
        void ShowViewAndWaitForClosing(Action _onViewClosed)
        {
            AView view = new AView();
            view.Show();
            view.Closed += (o, e) => { _onViewClosed(); };
        }
    }
