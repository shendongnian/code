        public BaseContext(Uri serviceRoot, DataServiceProtocolVersion maxProtocolVersion) :
            base(serviceRoot, maxProtocolVersion)
        {
            this.Configurations.RequestPipeline.OnEntryEnding(OnWritingEntryEnding);
        }
        private static readonly EntityStates[] _statesToPatchIfDirty = 
        { 
            EntityStates.Added, EntityStates.Modified 
        };
        /// <summary>
        /// Removes unmodified and client-only properties prior to sending an update or insert request to the server.
        /// </summary>
        protected virtual void OnWritingEntryEnding(WritingEntryArgs args)
        {
            var editableBase = args.Entity as EditableBase;
            if (editableBase != null 
                && editableBase.IsDirty 
                && _statesToPatchIfDirty.Contains(GetEntityDescriptor(args.Entity).State))
            {
                var cleanProperties = args.Entry
                                          .Properties
                                          .Select(odp => odp.Name)
                                          .Where(p => !editableBase.IsDirtyProperty(p))
                                          .ToArray();
                args.Entry.RemoveProperties(cleanProperties);
            }
        }
