        public void ProcessProjectModels()
        {
            var hostServiceProvider = (IServiceProvider)this.Host;
            var dte = (DTE)hostServiceProvider.GetService(typeof(DTE));
            using (TSqlModel model = new TSqlModel(SqlServerVersion.Sql110, new TSqlModelOptions { }))
            {
                foreach (Project project in dte.Solution)
                {
                    IterateThroughProject(project.ProjectItems, model);
                }
                List<TSqlObject> allTables = GetAllTables(model);
                foreach (var table in allTables)
                {
                    // Do processing 
                }
            }
        }
        public List<TSqlObject> GetAllTables(TSqlModel model)
        {
            List<TSqlObject> allTables = new List<TSqlObject>();
            var tables = model.GetObjects(DacQueryScopes.All, ModelSchema.Table);
            if (tables != null)
            {
                allTables.AddRange(tables);
            }
            return allTables;
        }
        
        private void IterateThroughProject(ProjectItems PrjItems, TSqlModel model)
        {
            foreach (ProjectItem PrjItem in PrjItems)
            {
                if (PrjItem.ProjectItems != null)
                {
                    IterateThroughProject(PrjItem.ProjectItems, model);
                }
                if (//PrjItem.Object.GetType().ToString() == "Microsoft.VisualStudio.Data.Tools.Package.Project.DatabaseFileNode" && 
                    PrjItem.Name.EndsWith(".sql", StringComparison.OrdinalIgnoreCase))
                {
                    // This is a sql file and will be processed
                    // Note: There should be a separate API to read the live contents of this item, to avoid the need to save it
                    if (!PrjItem.Saved)
                    {
                        PrjItem.Save();
                    }
                    StreamReader Reader = new StreamReader(PrjItem.FileNames[0]);
                    string Script = Reader.ReadToEnd();
                    model.AddOrUpdateObjects(Script, PrjItem.Name, null);
                }
            }
        }
