    public static Task<IList<MapLocation>> QuerryTaskAsync(this ReverseGeocodeQuery reverseGeocode)
        {
            TaskCompletionSource<IList<MapLocation> > tcs=new TaskCompletionSource<IList<MapLocation>>();
            EventHandler<QueryCompletedEventArgs<IList<MapLocation>>> queryCompleted = null;
            queryCompleted=(send, arg) =>
            {
                //Unregister event so that QuerryTaskAsync can be called several time on same object
                reverseGeocode.QueryCompleted -= queryCompleted;
                
                if (arg.Error != null)
                {
                    tcs.SetException(arg.Error);
                }else if (arg.Cancelled)
                {
                    tcs.SetCanceled();
                }
                else
                {
                    tcs.SetResult(arg.Result);
                }
            };
            reverseGeocode.QueryCompleted += queryCompleted;
            
            reverseGeocode.QueryAsync();
            return tcs.Task;
        }
