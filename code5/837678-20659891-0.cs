		protected override CreateParams CreateParams {
			get {
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;	// WS_EX_COMPOSITED
				return cp;
			}
		}
