        //From TabPage.cs
        public string ImageKey
        {
            get
            {
                return this.ImageIndexer.Key;
            }
            set
            {
                this.ImageIndexer.Key = value;
                TabControl parentInternal = this.ParentInternal as TabControl;
                if (parentInternal != null)
                {
                    this.ImageIndexer.ImageList = parentInternal.ImageList;
                }
                this.UpdateParent();
            }
        }
