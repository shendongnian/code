    public partial class ParticularEntity
    {
        public string UserId { get; set; }
        public void DoSomething(string userId)
        {
            someFunctionThatYouWantToNotBeAnExtension();
        }
    }
