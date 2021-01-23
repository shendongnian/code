    [RoutePrefix("tables/todolist")]
    public class ToDoListController : TableController<DataObjects.ToDoList>
    {
       ...
       // extended endpoint
       // GET tables/todolist/{key}/todolistitem
       [Route("{id:guid}/todolistitem")]
       public IQueryable<DataObjects.ToDoListItem> GetAllToDoListItemsForToDoList(string id)
       {
          return from l in Context.ToDoLists 
          join li in Context.ToDoListItems on l.Id equals li.ToDoListId
          where l.Id.Equals(id)
          select li;
       }
