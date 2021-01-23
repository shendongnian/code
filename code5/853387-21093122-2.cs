    private List<UserInformationProxy> GetContactsFromGuidList(List<Guid> contactList)
    {
        var qe = new QueryExpression(Contact.EntityLogicalName);
        qe.ColumnSet = new ColumnSet("fullname", "contactid")
        qe.Criteria.AddCondition("contactid", ConditionOperator.In, list.Cast<Object>().ToArray());
        qe.Distinct = true;
        var results = service.RetrieveMultiple(qe).Entities.Select (e => e.ToEntity<Contact>()).
            Select(x => new UserInformationProxy()
            {
                FullName = x.FullName,
                Id = x.ContactId
            });
        return results;
    }
