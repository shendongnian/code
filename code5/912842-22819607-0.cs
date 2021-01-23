    Function zPublishRange(oRng As Range)
        Dim oPub As PublishObject
        
        On Error GoTo Fail
        Set oPub = oRng.Parent.Parent.PublishObjects.Add(xlSourceRange, "D:\Output.htm", oRng.Parent.Name, oRng.Address, xlHtmlStatic)
        oPub.Publish True
        zPublishRange = oRng.Parent.Parent.PublishObjects.Count
        Exit Function
    Fail:
        zPublishRange = "Fail"
    End Function
