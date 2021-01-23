    using ReactiveUI;
    
    namespace ReactiveUIListBox.Model
    {
    	public class ReactiveModel<T> : ReactiveObject
    	{
    		public ReactiveModel()
    		{
    			TestList = new ReactiveList<T>();
    		}
    		public ReactiveList<T> TestList
    		{
    			get;
    			set;
    		}
    	}
    }
