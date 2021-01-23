    public Info GetByCompany(string company)
    {
        return InfoRepository.GetInfoByCompany(company);
    }
    public Info GetByContact(string contact)
    {
        return InfoRepository.GetInfoByContact(contact);
    }
