    public ActionResult Create(Role obj) {
        . . .
        for(int i = 0; i < obj.LdapGroupsSelected.Length; i++) {
            obj.LdapGroups.Add(new LdapObject(Convert.ToInt32(
                    obj.LdapGroupsSelected[i])));
        }
        session.Merge(obj);
    }
