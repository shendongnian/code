            bool helloflag = false;
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "hello")
            {
                Scot.Speak("Hello sir");
                helloflag = true;
            }
            if ((helloflag == true ) && (e.Result.Text == "how are you"))
            {
                Scot.Speak("im good sir");
                helloflag = false;
            }
        }
