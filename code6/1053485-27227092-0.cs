    public class MyTrapViewModel : ViewModelBase
    {
    	public MyTrapViewModel(Trap trap)
    	{
    	    Argument.IsNotNull(() => trap);
    	
    	    Trap = trap;
    	}
    	
    	[Model]
    	[Expose("CurrentValue")]
    	[Expose("TargetValue")]
    	private Trap Trap { get; set; }
    }
