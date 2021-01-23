    public virtual ObservableCollection<RelatedEntity> RelatedEntities { get; set; }
    [DatabaseGenerated( DatabaseGeneratedOption.Computed )]
    public int RelationshipCount { get; set; }
    void RelatedEntities_CollectionChanged( object sender, NotifyCollectionChangedEventArgs e )
    {
        var col = sender as ReadOnlyObservableCollection<RelatedEntity>;
        RelatedEntities = col.Count();
    }
