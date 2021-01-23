     private void ClearCache()
        {
            _repositoryFactory.GetSession().Clear();
            var sf = _repositoryFactory.GetSession().SessionFactory;
            sf.EvictQueries();
            foreach (var collectionMetadata in sf.GetAllCollectionMetadata())
                sf.EvictCollection(collectionMetadata.Key);
            foreach (var classMetadata in sf.GetAllClassMetadata())
                sf.EvictEntity(classMetadata.Key);
        }
