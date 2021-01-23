    private SpeechRecognizer speechRecognizer;
    private CoreDispatcher dispatcher;
    private StringBuilder dictatedTextBuilder;
    this.dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
    this.speechRecognizer = new SpeechRecognizer();
    SpeechRecognitionCompilationResult result =
    
    await speechRecognizer.CompileConstraintsAsync();
    speechRecognizer.ContinuousRecognitionSession.ResultGenerated +=
    ContinuousRecognitionSession_ResultGenerated;
    private async void ContinuousRecognitionSession_ResultGenerated(
    SpeechContinuousRecognitionSession sender,
    SpeechContinuousRecognitionResultGeneratedEventArgs args)
    {
    if (args.Result.Confidence == SpeechRecognitionConfidence.Medium ||
      args.Result.Confidence == SpeechRecognitionConfidence.High)
      {
        dictatedTextBuilder.Append(args.Result.Text + " ");
        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
          dictationTextBox.Text = dictatedTextBuilder.ToString();
          btnClearText.IsEnabled = true;
        });
      }
    else
    {
      await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
          dictationTextBox.Text = dictatedTextBuilder.ToString();
        });
    }
    }
