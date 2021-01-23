    public async Task<int> Read( byte[] buffer, int? size=null )
    {
        size = size ?? buffer.Length;
        using( var cts = new CancellationTokenSource() )
        {
            cts.CancelAfter( 1000 );
            try
            {
                return await stream.ReadAsync( buffer, 0, size.Value, cts.Token ).WithCancellation(cts.Token);
            }
            catch( OperationCanceledException cancel )
            {
                Debug.WriteLine( "cancelled" );
                return 0;
            }
            catch( Exception ex )
            {
                Debug.WriteLine( "exception" );
                return 0;
            }
        }
    }
