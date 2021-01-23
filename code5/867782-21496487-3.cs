    public partial class PlotMPhi : Window
    {
        public PlotMPhi(Collection<MeaMPhi> MeaMPhis)//double[] moment,double [] curvature)
        {
            var vm = new MVMMPhi(MeaMPhis);
            this.DataContext = vm;
            InitializeComponent();
        }
        private void SavePlot_Click(object sender, RoutedEventArgs e)
        {
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
        }
    }
    class MVMMPhi
    {
        public Collection<MeaMPhi> MeaMPhis { get; private set; }
        public MVMMPhi(Collection<MeaMPhi> Meamphis)
        {
            MeaMPhis = Meamphis;
            //Input ip = new Input();
            /*
            for (int i = 0; i < 40; i++)
            {
                MeaMPhis.Add(new MeaMPhi
                {
                    Curvature = curvature[i],
                    Moment = moment[i]
                });
            }
             */
        }
    }
    public class MeaMPhi
    {
        public double Curvature { get; set; }
        public double Moment { get; set; }
    }
