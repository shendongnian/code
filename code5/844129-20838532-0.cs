    public void comparisonGenerator()
    {
        // HERE: add currentFile check
        // Initialization
        List<FileLine> defaultLines = new List<FileLine>();
        List<FileLine> currentLines = new List<FileLine>();
        // HERE: add file reading to populate defaultLines and currentLines 
        // Comparison
        foreach(FileLine item in defaultLines)
        {
            // for the item with the same name (using Linq, you could do it easily):
            FileLine cLine = currentLines.Single(l => l.CsvName.Equals(item.CsvName));
            if(cLine != null)
            {
                processedLine = String.Format("result: {0} FMR_DIFF: {1} FNMR_DIFF: {2} SCORE_DIFF: {3}", item.CsvName, item.FmrValue - cLine.FmrValue, item.FnmrValue - cLine.FnmrValue, item.ScoreValue - cLine.ScoreValue);
                // HERE: add this line to future output
            }
        }
    
        // When all lines are processed, write the output to a file using FileStream
    }
