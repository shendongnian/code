	public void EnableUndo( bool enable )
	{
		if( IRichEditOleValue == null )
		{
			GetRichEditOleInterface();
		}
		IntPtr ptr = IntPtr.Zero;
		ITextDocumentValue.Undo( ( enable == true ) ? TomConstants.tomResume : TomConstants.tomSuspend, ptr );
	}
