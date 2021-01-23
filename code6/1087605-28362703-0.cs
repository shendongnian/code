    public void SuperDuperUniversal(CommonClass unknownDerived, string memb_name)
    {
        var member = unknownDerived.GetType().GetProperty(memb_name).GetValue(unknownDerived, null) as ObjDescr;
    
        string desc = member.Description;
    }
