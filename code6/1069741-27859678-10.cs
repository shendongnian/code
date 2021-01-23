    [TestFixture]
    public class Tests
    {
        public static void ExpectEventSequence(Queue<Action<EventHandler>> subscribeActions, Action triggerAction)
        {
            var expectedSequence = new Queue<int>();
            for (int i = 0; i < subscribeActions.Count; i++)
            {
                expectedSequence.Enqueue(i);
            }
            ExpectEventSequence(subscribeActions, triggerAction, expectedSequence);
        }
        public static void ExpectEventSequence(Queue<Action<EventHandler>> subscribeActions, Action triggerAction, Queue<int> expectedSequence)
        {
            var fired = new Queue<int>();
            var actionsCount = subscribeActions.Count;
            //This code has been commented out due to the fact that subscription is unknown here.
            //I stuck to use the last solution that Nick provided himself
    
            //for (var i = 0; i < actionsCount; i++)
            //{
            //    subscription((o, e) =>
            //    {
            //        fired.Enqueue(i);
            //    });
            //}
            var subscriptions = subscribeActions.ToList();
            foreach (var subscription in subscriptions)
            {
                subscription((o, e) =>
                {
                    var index = subscriptions.IndexOf(subscription);
                    Console.WriteLine("[ExpectEventSequence] Found index: {0}", index);
                    fired.Enqueue(index);
                });
            }
            triggerAction();
            var executionIndex = 0;
            var inOrder = true;
            foreach (var firedIndex in fired)
            {
                if (firedIndex != expectedSequence.Dequeue())
                {
                    inOrder = false;
                    break;
                }
                executionIndex++;
                Console.WriteLine("Execution index: {0}", executionIndex);
            }
            if (subscribeActions.Count != fired.Count)
            {
                Assert.Fail("Not all events were fired.");
            }
            if (!inOrder)
            {
                Console.WriteLine("Contents of Fired Queue: {0}", PrintValues(fired));
                Assert.Fail(string.Format(
                    CultureInfo.CurrentCulture,
                    "Events were not fired in the expected sequence from element {0}",
                    executionIndex));
            }
        }
        private static string PrintValues(Queue<int> myCollection)
        {
            return string.Format( "{{0}}", string.Join(",", myCollection.ToArray()));
             
        }
            
        [Test()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void FillFuel_Test([Values(1, 5, 10, 100)]float maxFuel)
        {  
            var fuelTank = new FuelTank()
            {
                MaxFuel = maxFuel
            };
            var eventHandlerSequence = new Queue<Action<EventHandler>>();
            eventHandlerSequence.Enqueue(x => fuelTank.FuelFull.FireEventHandler += x);
            //Dealing with a subclass of EventHandler
            eventHandlerSequence.Enqueue(x => fuelTank.FuelChanged.FireEventHandler += (o, e) => x(o, e));
            ExpectEventSequence(eventHandlerSequence, () => fuelTank.FillFuel());
        }
    }
