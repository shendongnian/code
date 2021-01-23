    public Func<bool> GenerateCheckIsLocal() {
    
                var dynamicMethod = new DynamicMethod("CheckIsLocal", typeof(bool), Type.EmptyTypes, true);
    
                var il = dynamicMethod.GetILGenerator();
    
                il.Emit(OpCodes.Call, typeof(HttpContext).GetProperty("Current").GetMethod);
                il.Emit(OpCodes.Call, typeof(HttpContext).GetProperty("Request").GetMethod);
                il.Emit(OpCodes.Call, typeof(HttpRequest).GetProperty("IsLocal").GetMethod);
                il.Emit(OpCodes.Ret);
    
                return dynamicMethod.CreateDelegate(typeof(Func<bool>)) as Func<bool>;
            }
