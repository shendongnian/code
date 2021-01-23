    private async Task<List<String>> GetEntiteesAsync()
    {
         using (var entities = new REPORTEntities())
         {
              return await (from user in entities.USERs
                             group user by user.entite into g
                                   select g.Key).ToListAsync();
         }
    }
