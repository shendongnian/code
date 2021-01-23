    public string DisplayName {
        get {
            if (string.IsNullOrEmpty(this._displayName)) {
                this._displayName = this.GetDisplayName();
    
                if (string.IsNullOrEmpty(this._displayName)) {
                    this._displayName = this.MemberName;
    
                    if (string.IsNullOrEmpty(this._displayName)) {
                        this._displayName = this.ObjectType.Name;
                    }
                }
            }
            return this._displayName;
        }   
    }
