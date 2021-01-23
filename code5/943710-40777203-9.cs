    //attach validation to Customer class.
    foreach (var property in typeof(Customer).GetProperties())
    {
        if (property.IsDefined(typeof(Email), true))
        {
            Aspect.Weave<Validation>(property.GetSetMethod(true));
        }
    }
