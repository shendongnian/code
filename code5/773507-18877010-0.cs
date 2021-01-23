        private static void DeleteAllDocuments(IDocumentStore documentStore)
        {
            documentStore.DatabaseCommands.DeleteByIndex("Auto/AllDocs", new IndexQuery());
            while (documentStore.DatabaseCommands.GetStatistics().StaleIndexes.Length != 0)
            {
                Thread.Sleep(10);
            }
        }
