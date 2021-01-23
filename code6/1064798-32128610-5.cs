    using ReactiveUI;
    
    namespace ReactiveUIListBox.Model
    {
    	public class ReactiveModel<T> : ReactiveObject
    	{
    		public ReactiveModel()
    		{
    			TestReactiveList= new ReactiveList<T>();
    		}
    		public ReactiveList<T> TestReactiveList
    		{
    			get;
    			set;
    		}
    	}
    }
