    /// instead of this
    .JoinAlias(() => subject.Localizations, () => localization, JoinType.LeftOuterJoin)
    .Where(() => localization.Language.Id == languageId 
              || localization.Language.Id == null);
    /// We can use this:
    .JoinAlias(() => subject.Localizations, () => localization, JoinType.LeftOuterJoin
                // the 4th param is appended to ON clause with AND operator
                , Restrictions.Where(() => localization.Language.Id == languageId
                                        || localization.Language.Id == null
                )
    )
