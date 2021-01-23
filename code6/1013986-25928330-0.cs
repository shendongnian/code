    static private void QuietClose(IDbConnection connection, ConnectionState originalState)
    {
          // close the connection if:
          // * it was closed on first use and adapter has opened it, AND
          // * provider's implementation did not ask to keep this connection open
          if ((null != connection) && (ConnectionState.Closed == originalState)) {
              // we don't have to check the current connection state because
              // it is supposed to be safe to call Close multiple times
              connection.Close();
          }
    }
    // QuietOpen needs to appear in the try {} finally { QuietClose } block
    // otherwise a possibility exists that an exception may be thrown, i.e. ThreadAbortException
    // where we would Open the connection and not close it
    static private void QuietOpen(IDbConnection connection, out ConnectionState originalState)
    {
        originalState = connection.State;
        if (ConnectionState.Closed == originalState) {
            connection.Open();
        }
    }
