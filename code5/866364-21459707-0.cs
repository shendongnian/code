    PERMISSIONS.Where(p =>
      PERMISSION_GROUP_REF.Where(pg =>
        GROUPS.Where(g =>
          GROUP_USER_REF.Where(gu => gu.USER_ID == USERID)
                        .Any(gu => gu.GROUP_ID == g.ID))
              .Any(g => g.ID == pg.GROUP_ID))
            .Any(pg => pg.PERMISSION_ID == p.ID))
