    private void performFirstStep(/*args*/)
    {
        //do stuff, throw if something goes wrong
    }
    private void performSecondStep(/*args*/)
    {
        //do stuff, throw if something goes wrong
    }
    public bool MyMethod(/*args*/)
    {
        try
        {
            // each method is supposed to represent a single Unit Of Work
            performFirstStep(/*args*/);
            performSecondStep(/*args*/);
            performThirdStep(/*args*/);
            return true;
        }
        catch(Exception ex) // I usually craft a custom exc. type to use here
        {
            // overly simplified catch block: you'll probably want
            // to *not* swallow the exceptions coming from the inside methods...
            // lots of possibilities here to easen debug
            return false;
        }
    } 
