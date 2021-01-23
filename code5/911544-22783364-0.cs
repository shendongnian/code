    public virtual ICollection<Role> Roles
    { 
        get
        {
            if (!this._roles.Any()) // initialized in the constructor
                this._roles.Add(new Role {...});
            return this._roles;
        }
        set { this._roles = value; }
    }
