    public GenericCollection FamilyTree
    {
        get { return _FamilyTree; }
        set
        {
            _FamilyTree = value;
            _FamilyTree.Owner = this;
        }
    }
