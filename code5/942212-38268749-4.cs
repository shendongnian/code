    using System;
    using System.Collections.Generic;
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
    /// Interaction logic for ButtonSample.xaml
    /// </summary>
    public partial class ButtonSample : UserControl
    {
        Corel.Interop.VGCore.Application appDraw = null;
        public ButtonSample()
        {
            InitializeComponent();
        }
        public ButtonSample(object app)
        {
            InitializeComponent();
            appDraw = (Corel.Interop.VGCore.Application)app;
        }
        private void buttonSample_Click(object sender, RoutedEventArgs e)
        {
            SelectOfType("rectangle");
        }
        private void SelectOfType(string strType)
        {
            string strQuery = null;
            Corel.Interop.VGCore.ShapeRange srGroup = default(Corel.Interop.VGCore.ShapeRange);
            Corel.Interop.VGCore.ShapeRange srTopOnly = default(Corel.Interop.VGCore.ShapeRange);
            strQuery = "@type='" + strType + "'";
            srGroup = appDraw.ActivePage.Shapes.FindShapes("", 0, true, strQuery);
            srTopOnly = appDraw.ActivePage.Shapes.FindShapes("", 0, false, strQuery);
            srTopOnly.CreateSelection();
            appDraw.ActivePage.Shapes.FindShapes("", 0, false, strQuery).CreateSelection();
            //if (srTopOnly.Count == srGroup.Count)
            //{
            //    lblWarning.Visibility = System.Windows.Visibility.Hidden;
            //}
            //else
            //{
            //    lblWarning.Visibility = System.Windows.Visibility.Visible;
            //}
        }
    }
