    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ModelVisual3D device = new ModelVisual3D();
            device.Content = getModel("hearse.3ds");
            viewport3D.Children.Add(device);
        }
        public Model3D getModel(string path)
        {
            Model3D device = null;
            try
            {
                viewport3D.RotateGesture = new MouseGesture(MouseAction.LeftClick);
                ModelImporter import = new ModelImporter();
                device = import.Load(path);
            }
            catch (Exception e)
            {                   }
            return device;
        }
}
}
