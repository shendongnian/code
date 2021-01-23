    public class Dummy : IModifiableDummy
    {
        public string Name { get; private set; }
    
        public void IModifiableDummy.SetName(string value)
        {
            this.Name = value;
        }
    }
    [Fact]
    public void Test()
    {
        var fixture = new Fixture();
        var dummy = fixture.Create<Dummy>();
        ((IModifiableDummy)dummy).SetName(fixture.Create<string>());
        // ...
    }
