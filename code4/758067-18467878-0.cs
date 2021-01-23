    interface IVisitor
    {
        void VisitCreateUserParams(CreateUserParams p);
        void VisitDeleteUserParams(DeleteUserParams p);
    }
    interface IParams
    {
        void Accept(IVisitor visitor);
    }
