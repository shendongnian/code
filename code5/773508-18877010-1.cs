        private static void DeleteFiles(IDocumentStore documentStore)
        {
            var staleIndexesWaitAction = new Action(
                delegate
                {
                    while (documentStore.DatabaseCommands.GetStatistics().StaleIndexes.Length != 0)
                    {
                        Thread.Sleep(10);
                    }
                });
            staleIndexesWaitAction.Invoke();
            documentStore.DatabaseCommands.DeleteByIndex("Auto/AllDocs", new IndexQuery());
            staleIndexesWaitAction.Invoke();
        }
