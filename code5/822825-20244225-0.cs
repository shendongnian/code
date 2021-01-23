    public class ActionTypes
    {
       private List<ActionType> list = context.GetAllActionTypes();
       private Dictionary<string, Guid> ActionTypesMap { get; private set; }
       public ActionTypes() {
         this.ActionTypesMap = list.ToDictionary(
           k => k.ActionTypeName,
           v => v.ActionTypeId);
       }
    }
