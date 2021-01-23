        public void DeactivateItemAndTryClose(IScreen item, bool close)
        {
            DeactivateItem(item, close);
            if(this.Items.Count == 0)
            {
                this.TryClose(); //No more tabs open, close window.
            }
        }
