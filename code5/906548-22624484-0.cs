    private ItemContainerRoot _myRoot;
    public ItemContainerRoot Root
    {
         get { return this._myRoot; }
         
         set
         {
             this._myRoot = value;
             
             this._myRoot.SetProgressBar += (val) => 
             { 
                  this.Invoke((Action)(() =>
                  {
                       this.progressBarControl1.Position = val;
                  }));
             };
         }
    }
