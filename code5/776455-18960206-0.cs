    list2.Join(list1,
               l2 => l2.CommunityID,
               l1 => l1.CommunityID,
               (item2, item1) =>
                   {
                       item2.CommunityName = item1.CommunityName;
                       return item2;
                   }
               ).ToList();
