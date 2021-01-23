    public class TestViewModel : DynamicObject
    {
       public override bool TryGetMember(GetMemberBinder binder, out object result)
       {
           result = null;
           return false; // if we didn't find member.
    
       }
    }
