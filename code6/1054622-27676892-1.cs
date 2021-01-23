    public void RegisterFakeData<T> (Context ctx,IEnumerable<T> list)
            {
                var name =typeof (T).Name;
                var mi = ctx.GetType().GetProperty(name).GetGetMethod();
                var args = new object[0] ;
                Isolate.WhenCalled(() =>(IEnumerable<T>)mi.Invoke(ctx,args)).WillReturnCollectionValuesOf(list);
            }
