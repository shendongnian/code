    private static int count = 0;
    void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        if(count == 0)
        {
            getSet.wordBefore = e.Result.Text;
            count = 1;
        }
        else
        {
           count = 0
     
     
            if (e.Result.Text == "hello")
            {
                Scot.Speak("Hello sir");
            }
            if ((getSet.wordBefore == "Hello") && (e.Result.Text == "how are you"))
            {
                Scot.Speak("im good sir");
  
            }
        }
    }
    public static class getSet
    {
        #region wordbefore
        private static string _WordBefore;
        public static string wordBefore
        {
            get {return _WordBefore;}
            set { _WordBefore = value;}
        }
        #endregion
    }
