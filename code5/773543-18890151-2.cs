    public List<IEntity> GetDataForRealm(IDocumentSession session, Realm realm)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (s, a) => MyResolveEventHandler(s, a, realm.Assembly);
            var realmData = session.Load<RealmData>(realm.RealmDataId);
            return realmData.Entities;
        }
