	public abstract class BasePoco
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
	}
	public class FirstPoco : BasePoco
	{
		public virtual List<BasePoco> ChildPocos { get; set; }
	}
	public class SecondPoco : BasePoco
	{
        
	}
    var secondCollection = first.ChildPoco.Where(x=>!x.IsDeleted);
