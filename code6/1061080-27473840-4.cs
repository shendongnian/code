    [Authorize(Roles="Moderators,Administrator")]
    public List<myObject> GetRestrictedData()
    {
        . . .
    }
