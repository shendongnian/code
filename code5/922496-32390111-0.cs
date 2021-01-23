    public IEnumerable<User> GetAll()
        {
            using (Database db = new Database())
            {
                var users = AutoMapper.Mapper.DynamicMap<List<User>>(db.Users);
                return users;
            }
        }
