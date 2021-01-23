    public enum CrudAction {
    	Add, Update, Get
    }
    
    public class UIController { 
        public void Perform(CrudAction action) {
     		switch(action){
    		    case CrudAction.Add: new AddAction().Perform(); break;
    		    case CrudAction.Get: new GetAction().Perform(); break;
    		    case CrudAction.Update: new UpdateAction().Perform(); break;
    		    default: throw new ArgumentException();
    		}
    	}
    }
    
    internal interface IAction {
    	void Perform();
    }
    
    internal class AddAction : IAction { }
    internal class GetAction : IAction { }
    internal class UpdateAction : IAction { }
