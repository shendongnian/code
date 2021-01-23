    	[DllImport("user32.dll")]
	public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
	[DllImport("user32.dll")]
	public static extern int GetMenuItemCount(IntPtr hMenu);
	[DllImport("user32.dll")]
	private static extern bool RemoveMenu(IntPtr hMenu, int uPosition, uint uFlags);
	protected override void OnHandleCreated(EventArgs e) {
		base.OnHandleCreated(e);
		const uint MF_BYPOSITION = 0x00000400;
		IntPtr hMenu = GetSystemMenu(this.Handle, false);
		int n = GetMenuItemCount(hMenu);
		RemoveMenu(hMenu, n-1, MF_BYPOSITION); // remove last (always close?)
	}
