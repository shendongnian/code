    public void LoadArrayList()
    {
        ActorArrayList.AddRange(File.ReadAllLines(filename));
    }
    
    public void PopulateActors()
    {
      cboActor.Items.Clear();
      cboActor.Items.AddRange(ActorArrayList.ToArray());
    }
