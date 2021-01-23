    var targetTypes = orignialList.GroupBy(o => o.Module)
        .Select(
            g =>
                new TargetType
                {
                    Module = g.Key,
                    Screen =
                        g.Select(t => new Screen {Permission = t.Permission, ScreenName = t.Screen}).ToList()
                }).ToList();
