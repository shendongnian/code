    protected partial class BaseForm : Form
    {
        var _recognizer = new SpeechRecognitionEngine();
        public BaseForm()
        {
            InitializeComponent();
            this.Load += FrmLoaded;
        }
        protected virtual void FrmLoaded(object sender, EventArgs e)
        {
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Shell_SpeechRecognized);
        }
        protected virtual void Shell_SpeechRecognized(object sender, EventArgs e)
        {
            //common code for handling this event
        }
    }
    public class frmMain : BaseForm
    {
        //override the stuff you need
    }
