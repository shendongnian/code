    public class RoughDynamicAdapter:DynamicObject{
        
        public override bool TryInvokeMember(InvokeMemberBinder binder,
    	                                    Object[] args,
    	                                    out Object result){
              if(binder.Name == "Foo"){
                result = /* do your own logic */
                return true;
              }
              result = null;
              return false;
        }
    }
