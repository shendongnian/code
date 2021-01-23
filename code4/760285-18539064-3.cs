    FileHelperEngine engine = new FileHelperEngine(typeof(contactTemplate)); 
    engine.BeforeReadRecord += BeforeEvent; 
    private void BeforeEvent(EngineBase engine, BeforeReadRecordEventArgs e)
    {
        if (e.RecordLine.Contains("\"))
        {
            string[] parts = SplitStringRespectingEscapeCharacter(eRecordLine);
            parts = QuoteAnyPartsWhichContainEscapeCharacter(parts);
            parts = RemoveAnyEscapeCharacters(parts);
            e.RecordLine = parts.Join;
        } 
    }
