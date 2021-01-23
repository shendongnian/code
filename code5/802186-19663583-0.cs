    ppPres.SaveAs(outputFilename);
    var presentations = ppApp.Presentations;
    
    if (presentations.Count <= 1)
    {
        ppPres.Close(); 
        ppApp.Quit();
    }
