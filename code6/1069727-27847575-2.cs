    class Test
    {
        public static void ExpectEventSequence(Queue<Action<EventHandler>> subscribeActions, Action triggerAction)
        {
            var expectedSequence = new Queue<int>();
            for (int i = 0; i < subscribeActions.Count; i++)
                expectedSequence.Enqueue(i);
            ExpectEventSequence(subscribeActions, triggerAction, expectedSequence);
        }
        public static void ExpectEventSequence(Queue<Action<EventHandler>> subscribeActions, Action triggerAction, Queue<int> expectedSequence)
        {
            var fired = new Queue<int>();
            var subscriptions = subscribeActions.ToList();
            foreach (var subscription in subscriptions)
            {
                subscription((o, e) =>
                {
                    var index = subscriptions.IndexOf(subscription);
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
            }
            if (subscribeActions.Count != fired.Count)
                Assert.Fail("Not all events were fired.");
            if (!inOrder)
                Assert
                    .Fail(string.Format(
                    CultureInfo.CurrentCulture,
                    "Events were not fired in the expected sequence from element {0}",
                    executionIndex));
        }
    }
    public class Fueled
    {
        public event EventHandler<FuelEventArgs> FuelChanged = delegate { };
        public event EventHandler FuelEmpty = delegate { };
        public event EventHandler FuelFull = delegate { };
        public event EventHandler FuelNoLongerFull = delegate { };
        public event EventHandler FuelNoLongerEmpty = delegate { };
        private float fuel;
        public float Fuel
        {
            get{ return fuel; }
            private set
            {
                var adjustedFuel = Math.Max(0, Math.Min(value, MaxFuel));
                if (fuel != adjustedFuel)
                {
                    var oldFuel = fuel;
                    fuel = adjustedFuel;
                    RaiseCheckFuelChangedEvents(oldFuel);
                }
            }
        }
        public void FillFuel()
        {
            Fuel = MaxFuel;
        }
        public float MaxFuel { get; set; }
        private void RaiseCheckFuelChangedEvents(float oldFuel)
        {
            FuelChanged(this, new FuelEventArgs(oldFuel, Fuel));
            if (fuel == 0)
                FuelEmpty(this, EventArgs.Empty);
            else if (fuel == MaxFuel)
                FuelFull(this, EventArgs.Empty);
            if (oldFuel == 0 && Fuel != 0)
                FuelNoLongerEmpty(this, EventArgs.Empty);
            else if (oldFuel == MaxFuel && Fuel != MaxFuel)
                FuelNoLongerFull(this, EventArgs.Empty);
        }
    }
    public class FuelEventArgs : EventArgs
    {
        public FuelEventArgs(float oldFuel, float fuel)
        {
        }
    }
    [TestFixture]
    public class Tests
    {
        [Test()]
        public void FillFuel_Test([Values(1, 5, 10, 100)]float maxFuel)
        {
            var fuelTank = new Fueled()
            {
                MaxFuel = maxFuel
            };
            var eventHandlerSequence = new Queue<Action<EventHandler>>();
            //Dealing with a subclass of EventHandler
            eventHandlerSequence.Enqueue(x => fuelTank.FuelChanged += (o, e) => x(o, e));
            eventHandlerSequence.Enqueue(x => fuelTank.FuelFull += x);
            Test.ExpectEventSequence(eventHandlerSequence, () => fuelTank.FillFuel());
        }
    }
