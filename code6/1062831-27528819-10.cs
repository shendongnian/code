	public class Data
	{
		public int Id { get; set; }
			//...
	}
	public class InfoData<TInfo> : Data where TInfo: InfoBase
	{
		public TInfo Info { get; set; }
			//...
	}
	/* Info classes */
	// ABSTRACT
	public abstract class InfoBase
	{
		public int Id { get; set; }
		//	...
	}
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
	class MainClass {
		public static TData Get<TData>(int id, int? related) where TData:Data{
			Console.WriteLine("id: {0}, related:{1}", id, related);
			return (TData)null;
		}
		public static TData Add<TData>(TData data) where TData:Data{
			return Get<TData>(data.Id,null);
		}
		public static TData Add<TData, TInfo>(TData data) where TInfo:InfoBase where TData:InfoData<TInfo>{
			var infoBase = data.Info as ExtraInfo;
			if (infoBase == null)
				return Get<TData>(data.Id,null);
			return Get<TData>(data.Id, infoBase.Related[0].Id);
		}
		public static void Main(string[] args) {
			var i = new ExtraInfo(){ Id = 5 , Related=new List<InfoBase>{new ExtraInfo{Id=1}}};
			var data = new InfoData<ExtraInfo>{ Id = 100, Info = i };
			var result1 = Add<InfoData<ExtraInfo>, ExtraInfo>(data);
			var result2 = Add(data);
		}
	}
