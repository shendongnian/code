        namespace CommonProblems.Algorithm.DynamicProgramming {
        public class Scheduler {
			#region init & test
			public List<Event> _events { get; set; }
			public List<Event> Init() {
				if (_events == null) {
					_events = new List<Event>();
					_events.Add(new Event(8, 11));
					_events.Add(new Event(6, 10));
					_events.Add(new Event(5, 9));
					_events.Add(new Event(3, 8));
					_events.Add(new Event(4, 7));
					_events.Add(new Event(0, 6));
					_events.Add(new Event(3, 5));
					_events.Add(new Event(1, 4));
				}
				return _events;
			}
			public void DemoOptimize() {
				this.Init();
				this.DynamicOptimize(this._events);
			}
			#endregion
			#region Dynamic Programming
			public void DynamicOptimize(List<Event> events) {
				events.Add(new Event(0, 0));
				events = events.SortByEndTime();
				int[] eventIndexes = getCompatibleEvent(events);
				int[] utilization = getBestUtilization(events, eventIndexes);
				List<Event> schedule = getOptimizeSchedule(events, events.Count - 1, utilization, eventIndexes);
				foreach (var e in schedule) {
					Console.WriteLine("Event: [{0}- {1}]", e.Start, e.End);
				}
			}
			/*
			Algo to get optimization value:
			1) Sort all events by end time, give each of the an index.
			2) For each event, find p[n] - the latest event (by end time) which does not overlap with it.
			3) Compute the optimization values: choose the best between including/not including the event.
		
			Optimize(n) {
				opt(0) = 0;
				for j = 1 to n-th {
					opt(j) = max(length(j) + opt[p(j)], opt[j-1]);
				}
				display opt();
			}
			*/
			int[] getBestUtilization(List<Event> sortedEvents, int[] compatibleEvents) {
				int[] optimal = new int[sortedEvents.Count];
				int n = optimal.Length;
				optimal[0] = 0;
				for (int j = 1; j < n; j++) {
					var thisEvent = sortedEvents[j];
					//pick between 2 choices:
					optimal[j] = Math.Max(thisEvent.Duration + optimal[compatibleEvents[j]],  //Include this event
										   optimal[j - 1]);									  //Not include
				}
				return optimal;
			}
			/* 
			Show the optimized events: 
				sortedEvents: events sorted by end time.
				index: event index to start with.
				optimal: optimal[n] = the optimized schedule at n-th event.
				compatibleEvents: compatibleEvents[n] = the latest event before n-th
			 */
			List<Event> getOptimizeSchedule(List<Event> sortedEvents, int index, int[] optimal, int[] compatibleEvents) {
				List<Event> output = new List<Event>();
				if (index == 0) {
					//base case: no more event
					return output;
				}
				//it's better to choose this event
				else if (sortedEvents[index].Duration + optimal[compatibleEvents[index]] >= optimal[index]) {
					output.Add(sortedEvents[index]);
					//recursive go back
					output.AddRange(getOptimizeSchedule(sortedEvents, compatibleEvents[index], optimal, compatibleEvents));
					return output;
				}
				//it's better NOT choose this event
				else {
					output.AddRange(getOptimizeSchedule(sortedEvents, index - 1, optimal, compatibleEvents));
					return output;
				}
			}
			//compatibleEvents[n] = the latest event which do not overlap with n-th.
			int[] getCompatibleEvent(List<Event> sortedEvents) {
				int[] compatibleEvents = new int[sortedEvents.Count];
				for (int i = 0; i < sortedEvents.Count; i++) {
					for (int j = 0; j <= i; j++) {
						if (!sortedEvents[j].IsOverlap(sortedEvents[i])) {
							compatibleEvents[i] = j;
						}
					}
				}
				return compatibleEvents;
			}
			#endregion
		}
		public class Event {
			public int EventId { get; set; }
			public bool IsOverlap(Event other) {
				return !(this.End <= other.Start ||
						this.Start >= other.End);
			}
			public override bool Equals(object obj) {
				var i = (Event)obj;
				return base.Equals(obj) && i.Start == this.Start && i.End == this.End;
			}
			public int Start { get; set; }
			public int End { get; set; }
			public Event(int start, int end) {
				Start = start;
				End = end;
			}
			public int Duration {
				get {
					return End - Start;
				}
			}
		}
		public static class ListExtension {
			public static bool ContainsOverlapped(this List<Event> list) {
				var sortedList = list.OrderBy(x => x.Start).ToList();
				for (int i = 0; i < sortedList.Count; i++) {
					for (int j = i + 1; j < sortedList.Count; j++) {
						if (sortedList[i].IsOverlap(sortedList[j]))
							return true;
					}
				}
				return false;
			}
			public static List<Event> SortByEndTime(this List<Event> events) {
				if (events == null) return new List<Event>();
				return events.OrderBy(x => x.End).ToList();
			}
		}
	}
