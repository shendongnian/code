    using System.Collections.ObjectModel;
    using System.Windows;
    
        namespace points
        {
            public class Bulb : DependencyObject
            {
                public double X
                {
                    get { return (double)GetValue(XProperty); }
                    set { SetValue(XProperty, value); }
                }
        
                public static readonly DependencyProperty XProperty =
                    DependencyProperty.Register("X", typeof(double), typeof(Bulb), new PropertyMetadata(0d));
        
                public double Y
                {
                    get { return (double)GetValue(YProperty); }
                    set { SetValue(YProperty, value); }
                }
        
                public static readonly DependencyProperty YProperty =
                    DependencyProperty.Register("Y", typeof(double), typeof(Bulb), new PropertyMetadata(0d));
        
                public Bulb NextBulb
                {
                    get { return (Bulb)GetValue(NextBulbProperty); }
                    set { SetValue(NextBulbProperty, value); }
                }
                public static readonly DependencyProperty NextBulbProperty =
                    DependencyProperty.Register("NextBulb", typeof(Bulb), typeof(Bulb), new PropertyMetadata(null));
        
            }
            public partial class MainWindow : Window
            {
                public ObservableCollection<Bulb> Bulbs
                {
                    get { return (ObservableCollection<Bulb>)GetValue(BulbsProperty); }
                    set { SetValue(BulbsProperty, value); }
                }
                public static readonly DependencyProperty BulbsProperty =
                    DependencyProperty.Register("Bulbs", typeof(ObservableCollection<Bulb>), typeof(MainWindow), new PropertyMetadata(null));
        
                public MainWindow()
                {
                    Bulbs = new ObservableCollection<Bulb>();
        
                    InitializeComponent();
        
                    for (int i = 0; i < 10; i++)
                    {
                        double x = i * 50;
                        double y = 25;
                        Bulbs.Add(new Bulb()
                            {
                                X = x,
                                Y = y,
                                NextBulb = i > 0 ? Bulbs[i - 1] : null,
                            });
                    }
        
                    Bulbs[5].Y = 50;
                }
            }
        }
