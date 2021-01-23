        void sre_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            lock (_lockObj)
            {
                timer.Enabled = false;
                //
                // Given the the explanation above, i should write the code for
                // setting of the ignoreSpeechInput flag like this:
                //   ignoreSpeechInput = isTimerElapsedHandlerExecuting ? true : false;
                //
                // But obviously that is the same as writing the following...
                //
                ignoreSpeechInput = isTimerElapsedHandlerExecuting;
            }
        }
