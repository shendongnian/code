    var yellows = odc.PersonAVCPermissions.Where(o => o.Status == (int)AVCStatus.Yellow);
    var q = from a in odc.AVCs
        from p in yellows.Where(o => o.AVCId == a.Id).Any()
        group a by new { a.Id, a.Name, a.Address } into agroup
        select new AVCListItem
        {
            Id = agroup.Key.Id,
            Name = agroup.Key.Name,
            Address = agroup.Key.Address,
            Count = agroup.Count(o => o.Id != null)
        };
