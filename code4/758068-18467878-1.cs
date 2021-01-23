    class CreateUserParams : IParams
    {
        public void Accept(IVisitor visitor) { visitor.VisitCreateUserParams(this); }
        public string Name { get; set; }
    }
    class DeleteUserParams : IParams
    {
        public void Accept(IVisitor visitor) { visitor.VisitDeleteUserParams(this); }
        public string Name { get; set; }
    }
