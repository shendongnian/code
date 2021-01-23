    public List<Dimensions> Consolidation(List<Dimensions> vm)
    {
        return vm.GroupBy(d=>new {d.TypeId, d.Width, d.Height}) // if there are any duplicates, they are grouped here
				.Select(g=>new Dimensions(){TypeId = g.Key.TypeId , 
                                            Width = g.Key.Width, 
                                            Height = g.Key.Height,
                                            PeacesForItem = g.Sum(dim=>dim.PeacesForItem)}) // number of duplicates in group calculated
				.ToList();
    }
