    List<EzClientEntity> listClient = getClientToSet();
    EzClientCollection colSel = new EzClientCollection ();
                    IPredicateExpression filtersSel = new PredicateExpression();
                    listClient.ForEach(o => filtersSel.AddWithOr((EzClientFields.ClientId  == o.ClientId ) & (EzClientFields.IsValited== o.IsValited )));
                    colSel.GetMulti(filtersSel);
