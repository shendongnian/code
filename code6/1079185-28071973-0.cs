    public interface IHasBars
    {
        List<Bar> Bars { get; }
    }
	
	public partial class _Default : Page, IHasBars
	{
		//...
	}
	
	public partial class UserControl : UserControl
	{
		private List<Bar> bars; 
        private List<Bar> Bars
        {
            get 
            {
                if (bars==null)
                {
                    var hasBars = Page as IHasBars;
                    if (hasBars != null)
                    {
                        return bars = hasBars.Bars;
                    }
                    throw new InvalidOperationException("You can only use this userControl inside a IHasBars");
                }
                return bars;
            }
        }
		
		//...
