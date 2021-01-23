    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Speech.Recognition;
    using System.Speech.Synthesis;
    using System.IO;
    using System.Xml;
    
    namespace J.A.R.V.I.S
    {
        public partial class Form1 : Form
        {
            SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
            SpeechSynthesizer JARVIS = new SpeechSynthesizer();
            string QEvent;
            string ProcWindow;
            double timer = 10;
            int count = 1;
            
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new DictationGrammar());
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"C:\Users\chaye\Documents\Commands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            string speech = e.Result.Text;
            MessageBox.Show(speech);
            string[] start_array={"start","some other words that sounds same as start or result from e.Result.Text when you say start"};
            if(start_array.Contains(speech))
              {
                SendKeys.SendWait("^{ESC}");
              }
        }
      }
}       
