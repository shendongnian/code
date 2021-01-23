            // NOTE: this way doesn't work.  It throws an error:
            //  System.RuntimeInteropServices.COMException (0x80004005): [Microsoft][ODBC Driver Manager] Data source name not found and no default driver specified at ADODB.Connection.Open
            //_connection = new Connection(_connectionString);
            //_connection.Open();
            // This way *does* work.
            _connection = new Connection();
            _connection.Open(_connectionString, null, null, 0);
