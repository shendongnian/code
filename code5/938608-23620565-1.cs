    public async Task<int> Read( byte[] buffer, int? size=null, 
        CancellationToken userToken)
    {
        size = size ?? buffer.Length;
        using( var cts = CancellationTokenSource.CreateLinkedTokenSource(userToken))
        {
            cts.CancelAfter( 1000 );
            try
            {
                var t =  stream.ReadAsync( buffer, 0, size.Value, cts.Token );
                try
                {
                    await t;
                }
                catch (OperationCanceledException ex)
                {
                    if (ex.CancellationToken == cts.Token)
                        throw new TimeoutException("read timeout", ex);
                    throw;
                }
                return t.Result;
            }
            catch( Exception ex )
            {
                Debug.WriteLine( "exception" );
                return 0;
            }
        }
    }
