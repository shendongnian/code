    private List<Item> _linkedItems;
    private void UpdateLinksTo() {
        this.LinksTo = string.Join<string>(_linkedItems.Select(i => i.ID.ToString()));
    }
    
    [NotMapped]
    public ReadOnlyCollection<Item> LinkedItems {
        get {
            if(_linkedItems == null) {
                _linkedItems = db.Items.Where(i => this.LinksTo.Split(',').Select(x => int.Parse(x)).Contains(i.ID)).ToList();
            }
            return _linkedItems.AsReadOnly();
        }
    }
    [NotMapped]
    public void AddLinkedItem(Item item) {
        if(!_linkedItems.Select(i => i.ID).Contains(item.ID)) {
            _linkedItems.Add(item);
            UpdateLinksTo();
        }
    }
