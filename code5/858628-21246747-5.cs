    Sub ReplaceAllText(ppPres As PowerPoint.Presentation)
        Dim ppSlide As PowerPoint.Slide
        
        For Each ppSlide In ppPres.Slides
            Call ReplaceTextShape("Hello", "Goodbye", ppSlide)
        Next ppSlide
        
        Set ppSlide = Nothing
    End Sub
