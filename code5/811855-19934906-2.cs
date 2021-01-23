    public int GetPage(int orderId, int sampleId, int itemsPerPage)
    {
        //protect against divide by zero
       if(itemsPerPage < 1)
          return 1;
      int index = _context.Set<Sample>()
                           .Where(s => s.OrderId == orderId && s.Id < sampleId)
                           .OrderBy(s => s.Id)
                           .Count();
   
       //if index is zero return 1
       //if index == 9 and itemsPerPage == 10 return 1 
       //if index == 10 and itemsPerPage == 10 return 2
       return 1 + (index / itemsPerPage);
    }
