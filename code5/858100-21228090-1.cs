    using(YourDBContext context = new YourDBContext())
    {
        Repository<User> userRepo = new Repository<User>(contex);
        userRepo.Insert(userEntity);
        Repository<Comment> commentRepo = new Repository<Comment>(context);
        commentRepo.Delete(commentEntity);
    }
