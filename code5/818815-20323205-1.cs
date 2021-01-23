    try
    {
         _client.EndConnect(result);
    }
    catch (Exception ex)
    {
         Disconnect();
         connectError = true;
    }
    using (_context = new Context(null, _client))
    {
          _context = new Context(null, _client);
          _context.BufferSize = 512;
          // some code
    }
