    void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e) 
         string result = e.Result.Text.ToString();
         if (result.startsWith("Write")) {
             richTextBox1.Text += result.substring(7); // Skip first 6 chars
         } else if (result.startsWith("Is it working")) {
             ss.SpeakAsync("Yes its working");
         }
    }
