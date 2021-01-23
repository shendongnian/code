    private List<UserInformationProxy> GetContactsFromGuidList(List<Guid> contactList)
    {
        var qe = new QueryExpression(Contact.EntityLogicalName);
        qe.Criteria.AddCondition("contactid", ConditionOperator.In, (IEnumerable)list);
        qe.Distinct = true;
        var results = service.RetrieveMultiple(qe).Entities.Select (e => e.ToEntity<Contact>()).
            Select(x => new UserInformationProxy()
            {
                FullName = x.FullName,
                Id = x.ContactId
            });
        return results;
    }
