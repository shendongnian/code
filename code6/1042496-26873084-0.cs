    Set(x => x.Skills, m =>
    {
        m.Schema("dbo");
        m.Table("UserPrivileges");
        m.Key(k => k.Column("UserID"));
        m.Cascade(Cascade.None);
    }, col => col.ManyToMany(m =>
    {
        m.Columns(x => x.Name("PrivilegeID"));
        m.Where("PrivilegeType = 'Skill'"); // <-----
    }));
