    class University : CommunityBase<IStudent>
    {
        public University(IStudent member)
            : base(member)
        {
        }
        public override void ShowName()
        {
            Console.WriteLine(_member.FirstName + " " + _member.LastName +
                 " Student-No. = " + _member.StudentNumber);
        }
    }
