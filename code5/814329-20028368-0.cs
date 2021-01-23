    static void RunTraining()
    {
        SpSharedRecoContext RC = new SpSharedRecoContext();
        string Title = "My App's Training";
        ISpeechRecognizer spRecog = RC.Recognizer;
        spRecog.DisplayUI(hWnd, Title, SpeechLib.SpeechUserTraining, "");
    }
