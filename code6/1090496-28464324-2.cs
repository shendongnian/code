    public static class ExpressionFactory 
    {
        public static Expression<Func<T, bool>> Get<T>(
             Expression<Func<T, MasterDocument>> mdSource, SecurityKey key) 
        {
            return mdSource.Compose(document => 
                document.Compartments.Where(c => c.AssociatedCompartment.Type != ProgramTypes.AccessGroup)
                        .All(c => key.Compartments.Contains(c.AssociatedCompartment.ID))
                        && (
                          doc.MasterDocument.NeedToKnowAccessList.Count() == 0
                        || doc.MasterDocument.NeedToKnowAccessList.Any(p => p.PersonID == key.PersonID)
                        || doc.MasterDocument.NeedToKnowAccessList.Any(p => key.AccessGroups.Contains(p.CompartmentID))
                           );
            
        }
    }
