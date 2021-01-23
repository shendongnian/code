    public class Anything {
        public virtual string Else() {
            return "wrong";
        }
    }
    [Test]
    public void x() {
        var o = Substitute.For<Anything>();
        o.Else().Returns("right");
        Assert.AreEqual("right", o.Else());
    }
