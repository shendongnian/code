	public string UserName {
		get {
			if (this.WorkEmail != null) {
				return this.WorkEmail.Address;
			}
			return null;
		}
		set {
			///	This property is non-settable.
		}
	}
