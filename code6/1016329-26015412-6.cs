    static void Main(string[] args)
    {
        FamilyList list = new FamilyList();
        
        Family.DisplaySameSex(list);
        // Or this when using the property `Families`:
        //Family.DisplaySameSex(list.Families);
    }
