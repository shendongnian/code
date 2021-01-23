    public decimal calculQuita(QUITA quita)
    {
        var total = 0d;
        // ...
        return commission; 
    }
    
    public void CalculCom(int id)
    {
        ...
        decimal totalCOM = 0;
        foreach (QUITA quita in quitaList)
        {
            totalCOM += calculQuita(quita);
        }
       ....
    }
