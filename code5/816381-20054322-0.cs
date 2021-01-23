    Survey surveyAlias = null;
    var result = 
    session.QueryOver<QuestionInSurvey>()
        .JoinAlias(x => x.Survey, () => surveyAlias)
        .WhereRestrictionOn(() => surveyAlias.AboutCompany).IsIn(companyAccounts.ToList())
        .And(x => x.ApprovalStatus == status)
        .Select(
            Projections.Distinct(
            Projections.ProjectionList()
                .Add(Projections.Property(() => surveyAlias.Id))
                .Add(Projections.Property(() => surveyAlias.AboutCompany))
                .Add(Projections.Property(() => surveyAlias.CreatedOn))
            )
        )
        .OrderBy(Projections.Property(() => surveyAlias.CreatedOn)).Desc
        .TransformUsing(Transformers.AliasToBean<Survey>())
        .List<Survey>();
