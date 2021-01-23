        void InformUser(string data)
        {
            // InvokeRequired tells you you're not on the correct thread to update the rtbPast
            if (rtbPast.InvokeRequired)
            {
                // Call InformUser(data) again, but on the correct thread
                rtbPast.Invoke(new Action<string>(InformUser), data);
  
                // We're done for this thread
                return;
            }
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream("IPSend.ns.wav");
            SoundPlayer player = new SoundPlayer(s);
            player.Play();
            TextRange tr = new TextRange(rtbPast.Document.ContentEnd, rtbPast.Document.ContentEnd);
            tr.Text = String.Format("{0} - Yorrick: {1} {2}", DateTime.Now.ToShortTimeString(), data, Environment.NewLine);
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            tr.ApplyPropertyValue(TextElement.BackgroundProperty, Brushes.Black);
        }
