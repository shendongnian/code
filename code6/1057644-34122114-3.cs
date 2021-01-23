        public async Task UpdateAsync(MyUser user)
        {
            _store.Context.Entry(user).State = EntityState.Modified;
            var result = await _store.Context.SaveChangesAsync();
            //var result =  await _manager.UpdateAsync(user);
        }
