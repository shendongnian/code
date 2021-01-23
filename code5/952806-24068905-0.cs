    Dim par As Paragraph
    
    'set reference to appropriate paragraph
    Set par = ActiveDocument.Paragraphs(2)
    
    Dim cc As ContentControl
    Set cc = ActiveDocument.ContentControls.Add( _
                wdContentControlRichText, par.Range)
            
    cc.Tag = "VERIFIED"
    
    'options
    'disable deletion of CC
    cc.LockContentControl = True
    
    'disable edition of CC
    cc.LockContents = True
