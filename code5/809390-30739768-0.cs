    [Test]
    public void Arrays_Should_Be_Equal()
    {
        MyClass[] array1 = GetTestArrayOfSize(10);
        MyClass[] array2 = GetTestArrayOfSize(10);
    
        // DOESN'T PASS
        // Assert.That(array1, Is.EquivalentTo(array2));
    
        Func<MyClass, object> selector = i => new { i.Property1, i.Property2 };
        Assert.That(array1.Select(selector), Is.EquivalentTo(array2.Select(selector)));
    }
  
    private MyClass[] GetTestArrayOfSize(int count)
    {
        return Enumerable.Range(1, count)
            .Select(i => new MyClass { Property1 = "Property1" + i, Property2 = "Property2" + i }).ToArray();
    }
