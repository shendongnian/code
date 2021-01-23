    var list = context.Packages
        .Join(context.Containers, p => p.ContainerID, c => c.ID, (p, c) => new { p, c })
        .Join(context.UserHasPackages, pc => pc.p.ID, u => u.PackageID, (pc, u) => new { pc.p, pc.c, u })
        .Where(pcu => pcu.u.UserID == "SomeUser")
        .Select(pcu => new
        {
            pcu.p.ID,
            pcu.c.Name,
            pcu.p.Code,
            pcu.p.Code2
        });
