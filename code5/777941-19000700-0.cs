    public void PopulateActors()
    {
        cboActor.Items.Clear(); 
        cboActor.Items.AddRange(ActorArrayList.ToArray());
    }
