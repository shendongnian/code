    class CameraViewModel : ViewModelBase {
        CameraServiceClass _camera_service;
        public System.Drawing.Bitmap Frame {
            get { return _frame; }
            set {
                _frame = value;
                RaisePropertyChanged(() => Frame);
            }
        }
        System.Drawing.Bitmap _frame;
        // CONSTRUTOR
        public CameraViewModel() {
            _camera_service = new CameraServiceClass();
            _camera_service.NovoFrame += new NovoFrameEventHandler(_camera_service_NovoFrame);
            _camera_service.Start();          
        }
        void _camera_service_NovoFrame(object sender, NovoFrameArgs e) {
            Frame = e.Frame;
        }
    }
