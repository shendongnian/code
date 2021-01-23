    public void MainFunction() 
    {
       try
       {
          SomeProblemFunction();
       }
       catch(Exception e)
       {
          Messagebox.Show(e.Message);
       }
    }
    
    private void SomeProblemFunction() {
        try{
            web call
        }
        catch{
             throw a specific exception related to this spot
        }
    }
    private void AllFineFunction() { ... }
