    void Main()
    {
        var permissions = new[] { "READ", "WRITE", "OPERATOR" };
        var check =
            new NamedPermission("READ")
            & new NamedPermission("WRITE")
            & !new NamedPermission("OPERATOR");
            
        check.ToString().Dump();
        check.HasPermission(permissions).Dump();
    }
    
    public abstract class Permission
    {
        public abstract bool HasPermission(IEnumerable<string> userPermissions);
        
        public static AndPermission operator &(Permission leftOperand, Permission rightOperand)
        {
            return new AndPermission(leftOperand, rightOperand);
        }
        
        public static OrPermission operator |(Permission leftOperand, Permission rightOperand)
        {
            return new OrPermission(leftOperand, rightOperand);
        }
        
        public static NotPermission operator !(Permission operand)
        {
            return new NotPermission(operand);
        }
    }
    
    public class NamedPermission : Permission
    {
        public NamedPermission(string name) { Name = name; }
        public string Name { get; private set; }
        
        public override bool HasPermission(IEnumerable<string> userPermissions)
        {
            return userPermissions.Contains(Name);
        }
        
        public override string ToString() { return Name; }
    }
    
    public abstract class BinaryPermissionOperator : Permission
    {
        public BinaryPermissionOperator(Permission leftOperand, Permission rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }
        
        public Permission LeftOperand { get; private set; }
        public Permission RightOperand { get; private set; }
    }
    
    public abstract class UnaryPermissionOperator : Permission
    {
        public UnaryPermissionOperator(Permission operand)
        {
            Operand = operand;
        }
        
        public Permission Operand { get; private set; }
    }
    
    public class AndPermission : BinaryPermissionOperator
    {
        public AndPermission(Permission leftOperand, Permission rightOperand)
            : base(leftOperand, rightOperand)
        {
        }
        
        public override bool HasPermission(IEnumerable<string> userPermissions)
        {
            return LeftOperand.HasPermission(userPermissions)
                && RightOperand.HasPermission(userPermissions);
        }
        
        public override string ToString()
        {
            return string.Format("{0} && {1}", LeftOperand, RightOperand);
        }
    }
    
    public class OrPermission : BinaryPermissionOperator
    {
        public OrPermission(Permission leftOperand, Permission rightOperand)
            : base(leftOperand, rightOperand)
        {
        }
        
        public override bool HasPermission(IEnumerable<string> userPermissions)
        {
            return LeftOperand.HasPermission(userPermissions)
                || RightOperand.HasPermission(userPermissions);
        }
        
        public override string ToString()
        {
            return string.Format("{0} || {1}", LeftOperand, RightOperand);
        }
    }
    
    public class NotPermission : UnaryPermissionOperator
    {
        public NotPermission(Permission operand)
            : base(operand)
        {
        }
        
        public override bool HasPermission(IEnumerable<string> userPermissions)
        {
            return !Operand.HasPermission(userPermissions);
        }
        
        
        public override string ToString()
        {
            return string.Format("!{0}", Operand);
        }
    }
