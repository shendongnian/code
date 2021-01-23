    public int ImageIndex {
      get { return ImageIndexer.Index;}
      set {
        ImageIndexer.Index = value;
        UpdateNode(NativeMethods.TVIF_IMAGE);
      }
    }
