    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics.Eventing.Reader;
    using System.Configuration;
    using System.Reactive.Linq;
     
    namespace AdfsEventLog
    {
        class Program
        {
            class AdfsAuditEventLogListener
            {
                private EventLogWatcher watcher;
     
                public AdfsAuditEventLogListener(string logName, string query)
                {
                    var events = Observable.FromEventPattern<EventRecordWrittenEventArgs>(
                        handler => this.watcher.EventRecordWritten += handler,
                        handler => this.watcher.EventRecordWritten -= handler);
     
                    this.watcher = new EventLogWatcher(new EventLogQuery(logName, PathType.LogName, query));
                    var pairs = events
                                  .Where(e299 => e299.EventArgs.EventRecord.Id == 299)
                                  .SelectMany(e299 => events.Where(e500 => e500.EventArgs.EventRecord.Id == 500 &&
                                                                           e299.EventArgs.EventRecord.Properties[0].Value.ToString() ==
                                                                           e500.EventArgs.EventRecord.Properties[0].Value.ToString())
                                                            .Take(1),
                                             (e299, e500) => new { First = e299, Second = e500 });
     
     
                    pairs.Subscribe(r =>
                    {
                        this.SuccessEventsWritten(this, new SuccessEventsWrittenEventArgs { Logs = new List<EventRecord>(new[] { r.First.EventArgs.EventRecord, r.Second.EventArgs.EventRecord }) });
                    });
                }
     
                public event EventHandler<SuccessEventsWrittenEventArgs> SuccessEventsWritten;
     
                public void Start()
                {
                    this.watcher.Enabled = true;
                }
     
                public void Stop()
                {
                    this.watcher.Enabled = false;
                }
     
            }
     
            class SuccessEventsWrittenEventArgs : EventArgs
            {
                public IList<EventRecord> Logs { get; set; }
            }
     
            static void Main(string[] args)
            {
                var listener = new AdfsAuditEventLogListener("Security", "*[System[(EventID=500 or EventID=299)]]");
                listener.SuccessEventsWritten += (sender, arg) =>
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
     
                    var e299 = arg.Logs.SingleOrDefault(@event => @event.Id == 299);
                    var e500 = arg.Logs.SingleOrDefault(@event => @event.Id == 500);
     
                    Console.WriteLine("Claims for: {0} (Correlation: {1})", e299.Properties[1].Value.ToString(), e299.Properties[0].Value.ToString());
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.WriteLine("\t{0}", string.Join("\n\t", e500.Properties
                                                                    .Skip(1)
                                                                    .Where(e => e.Value.ToString() != "-")
                                                                    .PairUp()
                                                                    .Select(t => t.Item1.Value.ToString() + " : " + t.Item2.Value.ToString())
                                                                    .ToArray()));
                };
     
                listener.Start();
     
                Console.WriteLine("Listening...");
                Console.ReadLine();
     
                listener.Stop();
            }
        }
     
        public static class EnumerableExtensions
        {
            public static IEnumerable<Tuple<T, T>> PairUp<T>(this IEnumerable<T> source)
            {
                using (var iterator = source.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        var first = iterator.Current;
                        var second = iterator.MoveNext() ? iterator.Current : default(T);
                        yield return Tuple.Create(first, second);
                    }
                }
            }
        }
    }
