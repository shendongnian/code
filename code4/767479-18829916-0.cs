    IEnumerable<Guid> fieldIds = glen.ComplianceField.Select(field => field.id);
    ComplianceData data;
        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.Serializable}))
            {
                foreach (Guid fieldId in fieldIds)
                {
                    if (collection[fieldId.ToString()] != null)
                    {
                        if (glen.ComplianceData.Where(compData => (compData.fieldId == fieldId) && (compData.grn == Extra.grn)).Count() == 0)
                        {
                            data = new ComplianceData();
                            glen.ComplianceData.Add(data);
                        }
                        else
                            data = glen.ComplianceData.First(compData => (compData.fieldId == fieldId) && (compData.grn == Extra.grn));
                            data.fieldId = fieldId;
                            data.grn = Extra.grn;
                            data.value = collection[fieldId.ToString()];
                    }
                }
                glen.SaveChanges();
                scope.Complete();
            }
