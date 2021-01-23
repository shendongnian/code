    ItemManager.PropertyChanged += (o, args) =>
    {
         if (args.PropertyName == "Root" && ItemManager.Root != null)
         {
              ItemManager.Root.SetProgressBar += (val) =>
              {
                   this.Invoke((Action)(() =>
                   {
                        this.progressBarControl1.Position = val;
                   }));
              };
         }
    };
