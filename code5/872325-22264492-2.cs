    public class DynamicAdapter:Dynamitey.DynamicObjects.BaseForwarder {
         public DynamicAdapter(object target):base(target){
         }
         public override bool TryInvokeMember(InvokeMemberBinder binder,
    	                                     Object[] args,
    	                                    out Object result){
              var newName = binder.Name;
              if(newName == "Foo"){
                 result = Dynamic.InvokeMember(CallTarget, "Bar", args)
                 return true;
              }
              //else pass them method on as it was called
              return base.TryInvokeMember(binder, args, out result)
        }
    }
