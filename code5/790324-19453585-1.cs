    private static object _result;
    internal class TimesTwoVisitor : VariantVisitor<int, string>
    {
        public void Visit(int item)
        {
            _result = item * 2;
        }
        public void Visit(string item)
        {
            _result = item + item;
        }
    }
    [Test]
    public void TestVisitVariant()
    {
        var visitor = new TimesTwoVisitor();
        var v = new Variant<int, string>();
        
        v.Set(10);
        v.ApplyVisitor(visitor);
        Assert.AreEqual(20, _result);
        v.Set("test");
        v.ApplyVisitor(visitor);
        Assert.AreEqual("testtest", _result);
        var v2 = new Variant<double, DateTime>();
        v2.Set(10.5);
        //v2.ApplyVisitor(visitor);
        // Argument 1: cannot convert from 'TestCS.TestVariant.TimesTwoVisitor' to 'TestCS.TestVariant.VariantVisitor<double,System.DateTime>'
    }
