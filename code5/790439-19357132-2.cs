    var query2 = (
        from users in Repo.T_Benutzer
        from mappings in Repo.T_Benutzer_Benutzergruppen.Where(mapping => mapping.BEBG_BE == users.BE_ID).DefaultIfEmpty()
        from groups in Repo.T_Benutzergruppen.Where(gruppe => gruppe.ID == mappings.BEBG_BG).DefaultIfEmpty()
        //where users.BE_Name.Contains(keyword)
        // //|| mappings.BEBG_BE.Equals(666)  
        //|| mappings.BEBG_BE == 666 
        //|| groups.Name.Contains(keyword)
        select new
        {
             UserId = users.BE_ID
            ,UserName = users.BE_User
            ,UserGroupId = mappings.BEBG_BG
            ,GroupName = groups.Name
        }
        );
    var xy = (query2).ToList();
