    public partial class ModalDialogWindow : Window
    {
        public ModalDialogWindow(IntPtr parentWindowHandle)
        {
            InitializeComponent();
            var interop = new WindowInteropHelper(this);
            interop.EnsureHandle();
            // this is it
            interop.Owner = parentWindowHandle;
        }
    }
