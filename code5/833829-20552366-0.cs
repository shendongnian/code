    List<int> dispoFilters = new List<int>();
    if (model.FilterSet.Dispositions != null)
    {
        for (int i = 0; i < model.FilterSet.Dispositions.Count; i++)
        {
            dispoFilters.Add((int)((RespondentStatus)Enum.Parse(typeof(RespondentStatus), model.FilterSet.Dispositions[i].ToString())));
        }
    }
