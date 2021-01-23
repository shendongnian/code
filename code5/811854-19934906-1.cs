    public int GetPage(int orderId, int sampleId, int itemsPerPage)
    {
       int index = _context.Set<Sample>()
                             .Where(s => s.OrderId == orderId && s.Id < sampleId)
                             .OrderBy(s => s.Id)
                             .Count();
       
       if(itemsPerPage < 1)
          return 1;
   
       return 1 + (index / itemsPerPage);
    }
