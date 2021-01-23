	public abstract class ListItemModelBase
	{
		public Guid Id { get; set; }
	}
	public class ListItem : ListItemModelBase
	{
	}
	public abstract class ListModelBase<T> where T : ListItemModelBase
	{
		public IEnumerable<T> Items { get; set; }
	}
	public class OrderListModel : ListModelBase<ListItem>
	{
	}
	public interface IListController<T>
	{
		T GetList(int page, int itemsPerPage);
	}
	public abstract class BaseController
	{
	}
	public class OrderListController : BaseController, IListController<OrderListModel>
	{
		public OrderListModel GetList(int page, int itemsPerPage)
		{
			return new OrderListModel();
		}
	}
