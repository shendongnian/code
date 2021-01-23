    public class Ref<T> where T : class
{
	private T instance;
	public Ref(T instance)
	{
		this.instance = instance;
	}
	
	public static implicit operator Ref<T>(T inner)
	{
		return new Ref<T>(inner);
	}
	public void Delete()
	{
		this.instance = null;
	}
	public T Instance
	{
		get { return this.instance; }
	}
