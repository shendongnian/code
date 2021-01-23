    @model dynamic
    @{
        var type = Model.GetType().GetProperties();
    }
    @foreach (System.Reflection.PropertyInfo property in type)
    {
        <p>@(property.Name) :</p>@property.GetValue(Model, null)
    }
