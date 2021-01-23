    public class SubstitutedClass
    {
        public virtual int SubstitutedProperty { get { return InnerValue(); } }
        public virtual int InnerValue() { throw new InvalidOperationException(); }
    }
    var test2 = Substitute.ForPartsOf<SubstitutedClass>();
    test2.When(t => t.InnerValue()).DoNotCallBase();
    test2.InnerValue().Returns(10);
