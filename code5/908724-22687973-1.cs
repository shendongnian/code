    public void CompareMyObjects(object object1, object object2)
    {
        var type1Fields = object1.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        var type2Fields = object2.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach (var t1Field in type1Fields)
        {
            var t2Field= type2Fields.SingleOrDefault(fi => fi.Name == t1Field.Name);
            if (t2Field==null)
                continue;
            Assert.AreEqual(t1Field.GetValue(object1), t2Field.GetValue(object2));
        }
    }
