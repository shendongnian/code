    public abstract class ListItemModel
    {
        public string UserName { get; set; }
    }
    public interface IListModel
    {
        List<ListItemModel> ListItems { get; }
    }
    public abstract class BaseListModel<T> : IListModel where T : ListItemModel
    {
        public List<T> Items { get; set; }
        public List<ListItemModel> ListItems
        {
            get { return Items.Cast<ListItemModel>().ToList(); }
        }
    }
    public class UserListModel : BaseListModel<UserListItemModel>
    {
        public string Query { get; set; }
        public int TotalUsers { get; set; }
    }
    public class UserListItemModel : ListItemModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    var users = new UserListModel
    {
        Query = "a",
        TotalUsers = 1111,
        Items = new List<UserListItemModel>
        {
            new UserListItemModel {FirstName = "a", LastName = "b"}
        }
    };
    // and finally I can cast the collection to IListModel
    var converted = users as IListModel;
    foreach (var item in converted .Items)
    {
        item.SomeProperty = DoSomethingHere(item.UserName);
    }
