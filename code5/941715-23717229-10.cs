        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (!ignoreSpeechInput)
            {
                if (e.Result.Text == "yes")
                    changeMode();
            }
            timer.Enabled = true;
        }
