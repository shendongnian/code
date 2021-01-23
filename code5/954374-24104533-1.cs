    	// this code will hide the close X button, since there is no CloseBox Form property
	protected override CreateParams CreateParams {
		get {
			const int CS_NOCLOSE = 0x0200;
			CreateParams param = base.CreateParams;
			param.ClassStyle = param.ClassStyle | CS_NOCLOSE;
			return param;
		}
	}
