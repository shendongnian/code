public class DataManager
{
    private readonly HashSet<object> data = new HashSet<object>();
    public void RegisterInstance(object instance)
    {
        data.Add(instance);
    }
    public void FreeInstance(object instance)
    {
        data.Remove(instance)
    }
}
public class Foo
{
    List<WeakReference<Bar>> bars = new List<WeakReference<Bar>>();
    private readonly DataManager dataManager;
    public Foo(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }
    public void LogSomething()
    {
        bars.Add( Bar.Create(dataManager, 3, "Susan"));
        bars.Add( Bar.Create(dataManager, 4, "Bob"));
        bars.Add( Bar.Create(dataManager, 0, "Megan"));
        dataManager.FreeInstance(bars[1]);
        CG.Collect();
        for(int i = bars.Count - 1; i >= 0; i--;)
        {
            // hard reference to not loose the reference target between now and logging
            Bar bar;
            if(!bars[i].TryGetTarget(out bar)
            {
                bars.RemoveAt(i);
                continue;
            }
            Debug.Log($"{bar.value.Data2} has {bar.value.Data1} chocolate bars");
        }
    }
}
public class Bar
{
    public int Data1 { get; private set; }
    public string Data2 { get; private set; }
    private Bar(int data1, string data2)
    {
        Data1 = data1;
        Data2 = data2;
    }
    public static WeakReference<Bar> Create(DataManager dataManager, int data1, string data2)
    {
        var bar = new Bar(data1, data2);
        dataManager.RegisterInstance(bar);
        return new WeakReference(bar);
    }
}
**Cons**
 - Weak references will continue to point to the target that was marked for deletion until it is actually garbage collected.
 - Running the garbage collector after each deletion isn't a very good idea
  - It's slow
  - Garbage collector might not even collect it. Meaning that a WeakReference can suddenly lose reference between two lines of code some time after deletion. This requires you to keep a hard reference everytime that you have to access the target of a weak reference more than just once.
 - You have to register every created object in the `DataManager`.
 - It's very easy to forget to use `WeakReference` to reference to objects.
 - `DataManager` screams to be static, which raises a red flag (atleast to me).
Approach 2: Use a wrapper
---
You can wrap all your objects in a generic class and only reference the wrapper.
public class Wraper<T>
{
    public T Value { get; private set; }
    public Wraper(T value)
    {
        Value = value;
    }
    public void Delete()
    {
        if(Value == null)
            throw new InvalidOperationException("Already deleted");
        Value = null;
    }
    public static implicit operator T(Wraper<T> wraper) => wraper.value;
    public static implicit operator Wraper<T>(T x) => new Wraper(x);
}
public class Foo
{
    List<Wraper<Bar>> bars = new List<Wraper<Bar>>();
    public void LogSomething()
    {
        bars.Add( new Bar(3, "Susan"));
        bars.Add( new Bar(4, "Bob"));
        bars.Add( new Bar(0, "Megan"));
        bars[1].Delete()
        for(int i = bars.Count - 1; i >= 0; i--;)
        {
            var bar = bars[i];
            if(bar.value == null)
            {
                bars.RemoveAt(i);
                continue;
            }
            Debug.Log($"{bar.value.Data2} has {bar.value.Data1} chocolate bars");
        }
    }
}
public class Bar
{
    public int Data1 { get; private set; }
    public string Data2 { get; private set; }
    public Bar(int data1, string data2)
    {
        Data1 = data1;
        Data2 = data2;
    }
}
You could also overwrite the `equals` method of `Wraper` to achieve the following behavior:
    var bar = new Wraper<Bar>(null);
    var isWrapedValueNull = bar == null;
    // overwrite 'equals' if you want isWrapedValueNull to be true in thia case
*I wrote this with the android app - example code might have minor errors*
