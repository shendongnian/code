    void sreRecognizedEvent(Object sender, SpeechRecognizedEventArgs e)
    {
        if(e.Result.Confidence >= 0.7)
        {
            Console.Write("Reconized ~ " + e.Result.Text + " ~ with confidence " + e.Result.Confidence);
            Console.WriteLine();
        }        
    }
