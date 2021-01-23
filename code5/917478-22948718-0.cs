    abstract class CommunityBase<T> where T : IPerson {
    {
        public abstract T Member { get; }
        public void ShowName() {
            Console.WriteLine(this.Member.FirstName + " " + this.Member.LastName);
        }
    }
    class University : CommunityBase<IStudent>
    {
        IStudent member;
        public University(IStudent member) {
            this.member = member;
        }
        
        public override IStudent Member { get { return member; } }
    }
        
