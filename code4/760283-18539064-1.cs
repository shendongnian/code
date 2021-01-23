    FileHelperEngine engine = new FileHelperEngine(typeof(contactTemplate)); 
    engine.BeforeReadRecord += BeforeEvent; 
    private void BeforeEvent(EngineBase engine, BeforeReadRecordEventArgs e)
    {
        if (e.RecordLine.Contains("\"))
        {
            string[] parts = SplitStringResepctingEscapeCharacter(eRecordLine);
            parts = QuoteAnyPartsWhichContainEscapeChracter(parts);
            parts = RemoveAnyEscapeCharacters(parts);
            e.RecordLine = parts.Join;
        } 
    }
