    private sealed class DynamicTypeAwareButton : UIButton
    {
        private readonly IObservable<Unit> dynamicTypeChanged;
        private readonly UIFont font;
        private SerialDisposable subscription = new SerialDisposable();
        public override void WillMoveToSuperView(UIView newView)
        {
            base.WillMoveToSuperView();
            // Whenever SerialDisposable.Disposable is assigned, it throws
            // away the previous one. That means, even if the Button gets
            // moved to a new non-null View, we're still not leaking a 
            // subscription
            if (newView != null) 
            {
                this.subscription.Disposable = this.dynamicTypeChanged
                    .StartWith(Unit.Default)
                    .Subscribe(_ => this.UpdateFont());
            } 
            else 
            {
                this.subscription.Disposable = Disposable.Empty;
            }
        }
        public void UpdateFont()
        {
            /* ... */
        }
    }
