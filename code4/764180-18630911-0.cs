	public class WorkoutContext {
		protected WorkOut mWorkOut;
		private static Dictionary<WorkOut, WorkoutContext> dic = new ...;
		private static object lockObj = new object();
		protected WorkoutContext(WorkOut workout)
		{
			 mWorkOut= workout;
		}
		public static WorkoutContext CreateContext(WorkOut workout)
		{   
			lock(lockObj) {
				 if (dic.ContainsKey(workout))
					  return dic[workout];
				 var wc = new WorkoutContext(workout)
				 dic.Add(workout, wc);
				 return wc;
			}
		}
	}
