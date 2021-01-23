public class Logger
{
	public PropertyLogger&lt;TPropertySource&gt; PropertyOf&lt;TPropertySource&gt;()
	{
		return new PropertyLogger&lt;TPropertySource&gt;();
	}
}
public class PropertyLogger&lt;TPropertySource&gt;
{
	public void Log&lt;TProperty&gt;(
		Expression&lt;Func&lt;TPropertySource, object&gt;&gt; property,
		TProperty initialValue,
		TProperty changedValue)
	{
	}
}
