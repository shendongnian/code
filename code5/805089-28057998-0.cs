class NotClosingCryptoStream : CryptoStream
{
	public NotClosingCryptoStream( Stream stream, ICryptoTransform transform, CryptoStreamMode mode )
		: base( stream, transform, mode )
	{
	}
	protected override void Dispose( bool disposing )
	{
		if( !HasFlushedFinalBlock )
			FlushFinalBlock();
		base.Dispose( false );
	}
}
