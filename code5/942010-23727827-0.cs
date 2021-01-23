    public void calculQuita(QUITA quita, ref decimal total)
    { ../
        total = commission; 
    
    }
    public void CalculCom(int id)
    {
        ...
        decimal totalCOM = 0;
        foreach (QUITA quita in quitaList)
        {
            decimal total = 0;
            calculQuita(quita,ref total);
            totalCOM += total;
        }
       ....
    }
