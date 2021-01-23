    public List<Changeset> Query(int id, List<Changeset> associatedChangesets)
    {            
        WorkItemStore _WorkItemStore = (WorkItemStore) __ProjectCollection.GetService(typeof(WorkItemStore));            
        WorkItem _WorkItem = _WorkItemStore.GetWorkItem(id);
    
        List<Changeset> _AssociatedChangesets;
    
        if (associatedChangesets == null)
        {
                _AssociatedChangesets = new List<Changeset>();
        }
        else
        {
            _AssociatedChangesets = associatedChangesets;
        }
    
        foreach (Link _Link in _WorkItem.Links)
        {
            RelatedLink _RelatedLink = null;
            ExternalLink _ExternalLink = null;
    
            if(_Link is RelatedLink)
            {
                _RelatedLink = (RelatedLink)_Link;
            }
            else if(_Link is ExternalLink)
            {
                _ExternalLink = (ExternalLink)_Link;
            }
                                             
            if (_ExternalLink != null)
            {
                ArtifactId _Artifact = LinkingUtilities.DecodeUri(_ExternalLink.LinkedArtifactUri);
                if (String.Equals(_Artifact.ArtifactType, "Changeset", StringComparison.Ordinal))
                {                        
                    _AssociatedChangesets.Add(__VersionControl.ArtifactProvider.GetChangeset(new Uri(_ExternalLink.LinkedArtifactUri)));
                }
            }
    
            if (_RelatedLink != null)
            {
                if (String.Equals(_RelatedLink.LinkTypeEnd.Name, "Child", StringComparison.Ordinal))
                {
                    associatedChangesets = Query(_RelatedLink.RelatedWorkItemId, _AssociatedChangesets);
                }
            }
        }
        return associatedChangesets;
    }
