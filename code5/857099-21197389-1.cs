    public class Assignment<T> {
        public readonly Expression Expression;
        public readonly object Value;
        
        public Assignment(Expression<Func<T, object>> expression, object value) {
            Expression = expression;
            Value = value;
        }
    }
    ...
    public static T GetNewData<T>(params Assignment<T>[] assignments)
                    where T : class, new() {
        var data = Activator.CreateInstance<T>();
        foreach (var assignment in assignments) {
            // todo:
            // - pull property names from assignment.Expression
            // - initialize nested properties / assign to assignment.Value
        }
        return data;
    }
    ...
    ExampleDataFactory.GetNewData<ServicesAndFeaturesInfo>(
        new Assignment<ServicesAndFeaturesInfo>(
            x => x.Property1.Property2.Property3.Property4, true));
