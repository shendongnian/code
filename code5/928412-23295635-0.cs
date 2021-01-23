        public static void CallSomeFunction(string SomeParameter, Action<string> Ok, Action Error, Activity Context)
		{
			ThreadPool.QueueUserWorkItem ((object e) => {
				var proxy = new YourProxyClass();
                proxy.Timeout = 10000;
				try{
					var res = proxy.YourFunction(SomeParameter);
				    Context.RunOnUiThread(() => Ok(res));
				}
				catch(Exception Ex){
					if(Error != null)
						Context.RunOnUiThread(Error);
				}
			});
		}
