    public async Task<int> Read( byte[] buffer, int? size=null )
    {
        size = size ?? buffer.Length;
        try
        {
            return await stream.ReadAsync( buffer, 0, size.Value, cts.Token ).TimeoutAfter(TimeSpan.FromSeconds(1));
        }
        catch( TimeoutException timeout )
        {
            Debug.WriteLine( "Timed out" );
            return 0;
        }
        catch( Exception ex )
        {
            Debug.WriteLine( "exception" );
            return 0;
        }
    }
