    public AangepastWerk CloneAdjustedWork(AangepastWerk pAdjustedWork)
    {
        return new AangepastWerk()
        {
            AangepastWerkID = pAdjustedWork.AangepastWerkID,
            ArbeidsOngeval = pAdjustedWork.ArbeidsOngeval,
            DatumCreatie = pAdjustedWork.DatumCreatie,
            DatumLaatsteWijziging = pAdjustedWork.DatumLaatsteWijziging,
            DatumOngeval = pAdjustedWork.DatumOngeval,
            GewijzigdDoor = pAdjustedWork.GewijzigdDoor,
            NietErkend = pAdjustedWork.NietErkend,
            Stamnummer = pAdjustedWork.Stamnummer,
            Verzorging = pAdjustedWork.Verzorging, <------------ Issue lies here
            VerzorgingId = pAdjustedWork.VerzorgingId
        };
    }
