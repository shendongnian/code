    public List<Dimensions> Consolidation(List<Dimensions> vm)
    {
        return vm.GroupBy(d=>new {d.TypeId, d.Width, d.Height})
				.Select(g=>new Dimensions(){TypeId = g.Key.TypeId , 
                                            Width = g.Key.Width, 
                                            Height = g.Key.Height,
                                            PeacesForItem = g.Sum(dim=>dim.PeacesForItem)})
				.ToList();
    }
