    public static TableBase GetTable(eDataType type)
    {
        switch (type)
        {
            case eDataType.company:
                return Companies;
            case eDataType.contact:
                return Contacts;
            case eDataType.person:
                return Persons;
        }
        return null;
    }
