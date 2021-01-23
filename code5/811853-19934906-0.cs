    public int GetPage(int orderId, int sampleId, int itemsPerPage)
    {
       int position= _context.Set<Sample>()
                             .Where(s => s.OrderId == orderId && s.Id <= sampleId)
                             .OrderBy(s => s.Id)
                             .Count();
       
   
       return 1 + (position / itemsPerPage);
    }
