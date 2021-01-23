Install() method example
    public override void Install(System.Collections.IDictionary stateSaver)
    {
        //Invoke the base class method
        base.Install(stateSaver);
    
        if (!keyEnteredByUser.Equals(generatedKey))
        {
           //This would abort the installation
           throw new Exception("Invalid Key");
        }
    }
