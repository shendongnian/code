    public class cls
    {
            [Category("Default")]
            [DisplayName("Street")]
            public string Street { get; set; }
    }
    foreach (PropertyInfo propinf in cls.GetProperties())
    {
      var category = prop.CustomAttributes.Where(x => x.AttributeType ==typeof(CategoryAttribute)).First();
    sCategory = category.ConstructorArguments[0].Value.ToString();
    }
