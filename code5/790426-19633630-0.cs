    internal class MarkUpdatedReferencesDirtyVisitor : VersionableVisitorBase
    {
        public MarkUpdatedReferencesDirtyVisitor(
            WcfRepositoryClient repositoryClient)
        {
            this.RepositoryClient = repositoryClient;
        }
        private WcfRepositoryClient RepositoryClient { get; set; }
        public override void BeginVisitItem(IVersionable item)
        {
            if (!this.HaveVisited(item.CompositeId) && !item.IsDirty)
            {
                base.BeginVisitItem(item);
                if (!item.IsPopulated)
                {
                    this.RepositoryClient.PopulateItem(
                        item,
                        true,
                        ChildReferenceProcessing.InstantiateLatest);
                }
                var latestChildren = item.GetChildren();
                var currentChildren = this.RepositoryClient.GetItem(
                        item.CompositeId,
                        ChildReferenceProcessing.Instantiate).GetChildren();
                if (latestChildren.Count != currentChildren.Count)
                {
                    item.IsDirty = true;
                }
                else
                {
                    for(int i = 0; i < currentChildren.Count; i++)
                    {
                        if (!latestChildren[i].CompositeId.Equals(
                            currentChildren[i].CompositeId))
                        {
                            item.IsDirty = true;
                            break;
                        }
                    }
                }
            }
        }
    }
