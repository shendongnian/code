    public partial class Form1 : Form
    {
        Form frm;  //Note class level declaration
        public Form1()
        {
            InitializeComponent();
        }
        private void Play_Click(object sender, EventArgs e)
        {
            string textToRead;
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = trackBarVolume.Value; // 0...100
            synthesizer.Rate = trackBarSpeed.Value; // -10...10
            textToRead = richTexBoxInput.Text;
            richTexBoxInput.Text = "";
            synthesizer.SpeakStarted += speakStarted;
            synthesizer.SpeakCompleted += synthesizer_SpeakCompleted;
            synthesizer.SpeakAsync(textToRead);  //Using SpeakAsync so that SpeakCompleted event will be shown
        }
        private void speakStarted(object sender, SpeakStartedEventArgs e)
        {
            frm = new Form();
            Label label = new Label();
            label.Text = "Please wait, the text is being read";
            frm.Controls.Add(label);
            frm.Show();
        }
        void synthesizer_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            frm.Close();
        }
    }
