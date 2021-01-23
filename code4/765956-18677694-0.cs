    public partial class SplashForm : Form
    {
        public SplashForm()
       {
        InitializeComponent();
       }
       //The type of form to be displayed as the splash screen.
       private static SplashForm splashForm;
       static public void Show(string txt)
       {
           // Make sure it is only launched once.
           if (splashForm != null)
           {
               splashForm.BeginInvoke(new MethodInvoker(delegate { splashForm.label1.Text =       txt; }));
               return;
           }
           Thread thread = new Thread((ThreadStart)delegate { ShowForm(txt); });
           thread.IsBackground = true;
           thread.SetApartmentState(ApartmentState.STA);
           thread.Start();
       }
       static private void ShowForm(string txt)
       {
           splashForm = new SplashForm();
           splashForm.label1.Text = txt;
           Application.Run(splashForm);
       }
   
       //Delegate for cross thread call to close
       private delegate void CloseDelegate();
       static public void CloseForm()
       {
           splashForm.Invoke(new CloseDelegate(SplashForm.CloseFormInternal));
       }
       static private void CloseFormInternal()
       {
           splashForm.Close();
       }
