    public abstract class Presenter<V> : IPresenter<V> {
        public Presenter(V view) { 
            View = view;
            OnShowView += View.OnShowView;
        }
        public void ShowView() { raiseShowViewEvent(); }
        public event VoidEventHandler OnShowView;
        private void raiseShowViewEvent() { if (OnShowView != null) OnShowView(); }
    }
