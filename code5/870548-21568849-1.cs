    let Address = BusinessInstanceInfoKeys.LocalityID != null
                  ? (from LocalityMaster1 in db.utblLocalityMasters
                     join BusinessInstance in db.utblYPBusinessInstanceInfoKeys
                       on BusinessInstance.LocalityID equals LocalityMaster1.LocalityID
                     select LocalityMaster1.LocalityName).FirstOrDefault()
                  : BusinessInstanceInfoKeys.BusinessAddress
