    class SubFactoty <T1,T2,T3>: IDelegateSubFactory{
     public Delegate GetActionConverter (Action<object[]> act){
         Action<T1,T2,T3> ans = (t1,t2,t3)=> act(new object[]{t1,t2,t3});
         return ans;
     }
    }
    class SubFactoty <T1,T2,T3,T4>: IDelegateSubFactory{
     public Delegate GetActionConverter (Action<object[]> act){
        Action<T1,T2,T3,T4> ans = (t1,t2,t3,t4)=> act(new object[]{t1,t2,t3,t4});
        return ans;
     }
    }
