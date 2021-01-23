    public static bool operator ==(Formula f1, Formula f2)
    {
        if (object.ReferenceEquals(f1, f2))
        { 
            return true; 
        }
        if (object.ReferenceEquals(f1, null) || object.ReferenceEquals(f2, null))
        {
            return false;
        }
        
        return f1.GetFormulaBasic() == f2.GetFormulaBasic();
    }
