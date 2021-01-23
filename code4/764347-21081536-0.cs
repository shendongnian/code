    public class CustomViewPresenter : MvxStoreViewPresenter {
        //XXX: Holding a ref here because base class's ref to the frame is for some reason private.
        private Frame _curFrame;
        public CustomViewPresenter(Frame RootFrame) : base(RootFrame) {
            _curFrame = RootFrame;
        }
        public override void Show(MvxViewModelRequest request) {
            try {
                var requestTranslator = Mvx.Resolve<IMvxViewsContainer>();
                var viewType = requestTranslator.GetViewType(request.ViewModelType);
                var converter = Mvx.Resolve<IMvxNavigationSerializer>();
                var requestText = converter.Serializer.SerializeObject(request);
                _curFrame.Navigate(viewType, requestText);
            } catch (Exception exception) {
                MvxTrace.Trace("Error seen during navigation request to {0} - error {1}", request.ViewModelType.Name,
                               exception.ToString());
            }
        }
    }
