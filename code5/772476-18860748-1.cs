    static void RunTraining(string[] TrainingText)
    {
        SpSharedRecoContext RC = new SpSharedRecoContext();
        string Title = "My App's Additional Training";
        ISpeechRecognizer spRecog = RC.Recognizer;
        spRecog.DisplayUI(hWnd, Title, SpeechLib.SpeechUserTraining, StringArrayToMultiString(TrainingText);
    }
