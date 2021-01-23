        public async Task UpdateAsync(MyUser user)
        {
            var result =  await _manager.UpdateAsync(user); //State = EntityState.Unchanged
            //ERROR! Primary key duplicate (Default identity method doing Attach :/ )
        }
