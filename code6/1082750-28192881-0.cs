    public List<Dimensions> Consolidation(List<Dimensions> vm)
        {
            var list = new List<Dimensions>();
            
            if (vm != null)
            {
                var dublicate = new List<Dimensions>(vm);
                var typeIds = vm.Select(x => x.TypeId).ToHashSet();
                foreach (var t in typeIds)
                {
                    foreach(var item in dublicate )
                    {
                        if (t == item.IvericaId)
                        {
                            int x = 0;
                            foreach (var again in dublicate )
                            {
                                if (item.Duzina == again.Duzina && item.Sirina == again.Sirina && item.TypeId== again.TypeId)
                                {
                                    x ++;
                                    vm.Remove(item); //Now working 
                                }
                            }
                            list.Add(
                                new Dimensions
                                {
                                    Width = item.Width,
                                    Height = item.Height,
                                    TypeId= item.TypeId,
                                    PeacesForItem = x * item.PeacesForItem,
                                }
                            );
                        }
                    }
                }
            }
            return list;
        }
