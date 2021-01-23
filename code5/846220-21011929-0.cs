    private UserAction GetIntendedUserAction(OperationDescription opDesc)
    {
        Type contractType = opDesc.DeclaringContract.ContractType;
        var attr = contractType.GetMethod(opDesc.Name).GeCustomAttributes(typeof(RequestedAction), false) as RequestedAction[];
        if (attr != null && attr.Length > 0)
        {
            return attr[0].ActionName;
        }
        else
        {
            return UserAction.Unknown;
        }
    }
    public enum UserAction
    {
        Unknown = 0,
        View = 1,
        Control = 2,
        SysAdmin = 3,
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class RequestedAction : Attribute
    {
        public UserAction ActionName { get; set; }
        public RequestedAction(UserAction action)
        {
            ActionName = action;
        }
    }
