    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CoreDrawPoC
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class MySlider : UserControl
        {
            Corel.Interop.VGCore.Application appDraw = null;
            public MySlider()
            {
                InitializeComponent();
            }
    
            public MySlider(object app)
            {
                InitializeComponent();
                appDraw = (Corel.Interop.VGCore.Application)app;
            }
    
            private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            {
                if (appDraw != null && appDraw.ActiveDocument != null && appDraw.ActiveShape != null)
                {
                    double width = appDraw.ConvertUnits((double)e.NewValue, Corel.Interop.VGCore.cdrUnit.cdrPoint, Corel.Interop.VGCore.cdrUnit.cdrInch);
                    appDraw.ActiveSelectionRange.SetOutlineProperties(width);
                }
            }
        }
    }
