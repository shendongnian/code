    public string PartQueryString { 
        get
        {
            return _partQueryString;
        } 
        set
        {
            if (_partQueryString != value)
            {
                _partQueryString = value;
                //observe this value and trigger a search when it changes
                this.PartMaster.DataSource = _model.SearchPartMaster(_partQueryString);
                _view.UpdateGridViewPosition();
            }
        }
    }
