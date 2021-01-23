		protected override void OnActivated(IActivatedEventArgs e)
		{
			// Handle when app is launched by Cortana
			if (e.Kind == ActivationKind.VoiceCommand)
			{
				VoiceCommandActivatedEventArgs commandArgs = e as VoiceCommandActivatedEventArgs;
				SpeechRecognitionResult speechRecognitionResult = commandArgs.Result;
		 
				string voiceCommandName = speechRecognitionResult.RulePath[0];
				string textSpoken = speechRecognitionResult.Text;
				IReadOnlyList<string> recognizedVoiceCommandPhrases;
		 
				System.Diagnostics.Debug.WriteLine("voiceCommandName: " + voiceCommandName);
				System.Diagnostics.Debug.WriteLine("textSpoken: " + textSpoken);
		 
				switch (voiceCommandName)
                ...
