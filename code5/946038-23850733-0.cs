    public SelectList SelectedStatsList { get; private set; } 
    public StatModel() 
    {
      StatsList = new List<string> {"agR", "demandeR" };
      SelectedStatsList = new SelectList(StatsList);
    }
