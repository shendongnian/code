    public override void ActivateItem(DocumentViewModel item)
    {
        _countActivated++;
        base.ActivateItem(item);
    }
 
    public override void DeactivateItem(DocumentViewModel item, bool close)
    {
         _countDeactivated++;
         base.DeactivateItem(item, close);
    }
