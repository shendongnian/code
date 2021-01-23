    class CommandHandler : IVisitor
    {
        public void VisitCreateUserParams(CreateUserParams p)
        {
            Console.WriteLine("Creating " + p.Name);
        }
        public void VisitDeleteUserParams(DeleteUserParams p)
        {
            Console.WriteLine("Deleting " + p.Name);
        }
    }
