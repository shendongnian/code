        initialList.ForEach(p =>
        {
            if (secondList.Any(sp => sp.Value == p.Value))
            {
                initialList.Remove(p);
                initialList.Add(secondList.Single(spu => spu.Value == p.Value));
            };
        });
