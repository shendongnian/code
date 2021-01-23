    public class AccountController : TableController<Account>
    {
    ...
    // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
       public Task<Account> PatchAccount(string id, Delta<Account> patch)
       {    
           if(IsValidDelta(patch))        
                return UpdateAsync(id, patch);          
           else
              // forbidden...
       }
    ...
    }
