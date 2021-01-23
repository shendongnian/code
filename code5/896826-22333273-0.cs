        using System.Collections.Generic;
        using System.Windows;
        namespace WpfApplication1 {
            public class PointCoordinate {
                public double X { get; set; }
                public double Y { get; set; }
            }
            public class PointCoordinate2 : PointCoordinate {
                public string key { get; set; }
            }
            public partial class MainWindow : Window {
                public MainWindow() {
                    InitializeComponent();
                    Dictionary<string, PointCoordinate> PointCoordinates = new Dictionary<string, PointCoordinate>();
                    PointCoordinates.Add("Number 1", new PointCoordinate() { X = 1, Y = 4 });
                    PointCoordinates.Add("Number 2", new PointCoordinate() {X = 2, Y = 5});
                    PointCoordinates.Add("Number 3", new PointCoordinate() {X = 3, Y = 6});
                    List<PointCoordinate2> lList = new List<PointCoordinate2>();
                    foreach (var lItem in PointCoordinates) {
                        PointCoordinate2 lPC2 = new PointCoordinate2();
                        lPC2.key = lItem.Key;
                        lPC2.X = lItem.Value.X;
                        lPC2.Y = lItem.Value.Y;
                        lList.Add(lPC2);
                    }
                    //var n = from x in PointCoordinates select ;
                    myDataGrid.AutoGenerateColumns = true;
                    myDataGrid.ItemsSource = lList;
                }
            }
        }
