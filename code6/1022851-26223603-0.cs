    public List<T> SearchApplications<T>(SearchModel<T> model)
    {
        if (model is A)
        {
            return SearchVerificationsForA(model);
        }
        else if (model is B)
        {
            return SearchApplicationsForB(model);
        }
    }
