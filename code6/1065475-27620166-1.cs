    public static IEnumerable<IDbCommand> ToIDbCommands(this ICriteria criteria)
            {
                 var criteriaImp = criteria as CriteriaImpl;
                if (criteriaImp == null)
                    throw new InvalidOperationException();
                var implementors = criteriaImp.Session.Factory.GetImplementors(criteriaImp.EntityOrClassName);
                var loaders = new CriteriaLoader[implementors.Length];
                for (var i = 0; i < implementors.Length; i++)
                {
                    loaders[i] = new CriteriaLoader((IOuterJoinLoadable) typeof(SessionImpl).GetMethod("GetOuterJoinLoadable",BindingFlags.Instance | BindingFlags.NonPublic).Invoke(criteriaImp.Session,new object[]{implementors[i]}), criteriaImp.Session.Factory, criteriaImp, implementors[i], criteriaImp.Session.EnabledFilters);
                }
    
                return
                    loaders.Select(
                        loader => (IDbCommand)loader.GetType().GetMethod("PrepareQueryCommand", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(loader,new object[]{ loader.Translator.GetQueryParameters(),false, criteriaImp.Session}));
            }
