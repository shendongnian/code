    var items = groups
        .SelectMany(group => group.SubGroups, (group, subGroup) => new
            {
                group,
                subGroup
            })
        .SelectMany(anon => anon.subGroup.Items, (anon, item) => new
            {
                anon.group.MainGroupId,
                anon.subGroup.SubGroupId,
                item.ItemMpId
            });
