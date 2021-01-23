    class TopNavigationConst {
    	public const string Save = "Save";
        public const string Refresh = "Refresh";
    }
    
    class ControlsConst {
    	public const TopNavigationConst TopNavigation = new TopNavigationConst();
    }
    
    public class ErrorsConst
    {
    	public const string UnexpectedError = "An unexpected error occured.";
    }
    
    public class GeneralConst
    {
    	public const ErrorsConst Errors = new ErrorsConst();
    }
    
    public class Labels
    {
    	public const ControlsConst Controls = new ControlsConst();
    	public const GeneralConst General = new GeneralConst();
    }
    
    public class Constants
    {
    	public const LabelsConst Labels = new LabelsConst();
    }
