    public class Main
    {
        public void CheckData()
        {
            try
            {
                ProgressBar.ShowProgressBar();
                //do data checking here
                ProgressBar.CloseForm();
            }   
            catch(Exception e)
            {
            }
       }
    }
    public partial class ProgressBar : Form
    {
        static ProgressBar _progressBarInstance;
        public ProgressBar()
        {
            InitializeComponent();
            //DoWork();
        }
        static void ShowForm()
        {
            _progressBarInstance = new ProgressBar();
            Application.Run(ms_ProgressBar);
        }
        public static void CloseForm()
        {
             Invoke(new Action(Close));
             _progressBarInstance= null;
        }
        public static void ShowProgressBar()
        {
            // Make sure it is only launched once.
            if (_progressBarInstance != null)
               return;
            var ms_oThread = new Thread(new ThreadStart(ShowForm));
            ms_oThread.IsBackground = true;
            ms_oThread.SetApartmentState(ApartmentState.STA);
            ms_oThread.Start();
        }
    }
