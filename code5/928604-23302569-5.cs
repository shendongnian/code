    public static void SetDefaultNamingConvention<T>(this T toDefault)
    {
        foreach (PropertyInfo p in toDefault.GetType().GetProperties()
                         .Where(p=> p.PropertyType == typeof(Class1)))
        {
            foreach (var dv in p.GetCustomAttributes(true).OfType<DefaultValueAttribute>())
            {
                var pValue = p.GetValue(toDefault, null) as Class1;
                if (pValue != null)
                {
                    pValue.Naming = ((Class1)dv.Value).Naming;
                }
                else
                {
                    p.SetValue(toDefault, dv.Value, null);
                }
            }
        }
    }
    [Test]
    public void SetDefaultNamingConventionDefaultShouldOnlyDefaultNamingProperty()
    {
        var c3 = new Class3();
        c3.Name3Class.Naming = NamingConvention.Name1;
        c3.Name3Class.Id = 20;
        c3.SetDefaultNamingConvention();
        Assert.That(c3.Name3Class.Id, Is.EqualTo(20));
        Assert.That(c3.Name3Class.Naming, Is.EqualTo(NamingConvention.Name3));
    }
