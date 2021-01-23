     public MainWindow() {
          InitializeComponent();
           SpeechSynthesizer reader = new SpeechSynthesizer();
    
           reader.SpeakCompleted += Reader_SpeakCompleted;
      }
    
       void Reader_SpeakCompleted(object sender, SpeakCompletedEventArgs e) {
         
       }
