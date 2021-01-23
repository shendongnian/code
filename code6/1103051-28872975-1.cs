    namespace WpfApplication1
    {
      public partial class CtrlComments : UserControl
      {
        public static readonly DependencyProperty DeploymentProperty =
          DependencyProperty.Register("Deployment", typeof(DeploymentDto), typeof(CtrlComments), new PropertyMetadata(new DeploymentDto { Id = 5 }));
    
        public DeploymentDto Deployment
        {
          get { return (DeploymentDto)GetValue(DeploymentProperty); }
          set
          {
            SetValue(DeploymentProperty, value);
          }
        }
    
        public CtrlComments()
        {
          InitializeComponent();
        }
      }
    }
