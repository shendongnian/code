    void Main()
    {
        var c = new C();
        // TODO: Check if C implements I
        var i = c.GetType().GetInterface("I");
        if (i != null)
        {
            var valueProperty = i.GetProperty("Value");
            var value = valueProperty.GetValue(c);
            Debug.WriteLine(value);
        }
    }
    
    public interface I
    {
        string Value { get; }
    }
    
    public class C : I
    {
        string I.Value { get { return "Test"; } }
    }
