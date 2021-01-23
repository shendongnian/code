    public Cell(IGameViewer viewer, Tuple<int, int> coords) {
      this.viewer = viewer;
      ...
    
      if (!Object.ReferenceEquals(null, OnCellCreated))
        OnCellCreated(this); 
      ...
    }
