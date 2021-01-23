    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Controls.Primitives;
    
    namespace CustomBorderStyle
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                //wire up the popup to the popup placement method
                myPopup.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
            }
    
            private void btnThingToClick_Click(object sender, RoutedEventArgs e)
            {
                //just invert if it's open or not
                myPopup.IsOpen = !myPopup.IsOpen;
            }
    
    
            //this is to position the popup next to the button
            public CustomPopupPlacement[] placePopup(Size popupSize,
                                               Size targetSize,
                                               Point offset)
            {
                CustomPopupPlacement placement1 =
                   new CustomPopupPlacement(new Point(10, -200), PopupPrimaryAxis.Vertical);
    
                CustomPopupPlacement placement2 =
                    new CustomPopupPlacement(new Point(10, 20), PopupPrimaryAxis.Horizontal);
    
                CustomPopupPlacement[] ttplaces =
                        new CustomPopupPlacement[] { placement1, placement2 };
                return ttplaces;
            }
        }
    }
