        public async Task UpdateAsync(MyUser user)
        {
            var result =  await _manager.UpdateAsync(user); //State = EntityState.Unchanged
            //UpdateAsync above is directly inherited from Microsoft.AspNet.Identity.EntityFramework.UserManager<T>
            //ERROR! Primary key duplicate (Default identity method doing Attach :/ )
        }
