    public class Factory
    {
    	public App.ModelA Initizlize(App.ModelA source)
    	{
    		 source.SomeTable = (App.TableModel)App.Defaults.Initializer[typeof(App.TableModel)].Invoke();
    		 return source;
    	}
    	public App.ModelB Initizlize(App.ModelB source)
    	{
    		 source.SomeGraph2 = (App.TableModel)App.Defaults.Initializer[typeof(App.TableModel)].Invoke();
    		 return source;
    	}
    }
