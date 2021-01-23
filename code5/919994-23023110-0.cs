    private void NumberButtons(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if ((b == null) || (b.Text == "0" && buffer.Length == 0))
            return;
        buffer += b.Text;
        txtOutput.Text = buffer;
        if (txtOutput.Text != "")
        {
            if (toCancel.Count > 0)
            {
                foreach (var tc in toCancel)
                {
                    tc.Cancel();
                }
            }
            CancellationTokenSource ts = new CancellationTokenSource();
            CancellationToken ct;
            ct = ts.Token;
            toCancel.Add(ts);
           
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                if (ct.IsCancellationRequested == false)
                {
                    SpVoice voice = new SpVoice();
                    voice.Volume = 100;
                    voice.Speak(txtOutput.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
                }
            }, ct);
        }
    }
