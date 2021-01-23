    public int GetPage(int orderId, int sampleId, int itemsPerPage)
    {
        //protect against divide by zero
       if(itemsPerPage < 1)
          return 1;//or 0 if you want page index
      int index = _context.Set<Sample>()
                           .Where(s => s.OrderId == orderId && s.Id < sampleId)
                           .OrderBy(s => s.Id)
                           .Count();
   
       //if index is zero return 1
       //if index == 9 and itemsPerPage == 10 return 1 
       //if index == 10 and itemsPerPage == 10 return 2
       //if you want the page index rather than the page number don't add 1
       return 1 + (index / itemsPerPage);
    }
