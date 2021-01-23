	public interface IRelated{
		IList<InfoBase>Related {get; set;}
	}
	public class ExtraInfo : InfoBase, IRelated
	{
		public IList<InfoBase> Related { get; set; }
	}
	public class OtherInfo:IRelated{
		public IList<InfoBase> Related { get; set; }
	}
