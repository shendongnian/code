    public void SetProgress(int level)
    {
          if (this.InvokeRequired)
          {
            SetProgressDelg dlg = new SetProgressDelg(this.SetProgress);
            this.Invoke(dlg, level);
            return;
          } 
          progressBar.Value = level;
    }
