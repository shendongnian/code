    interface IThing { }
    class Thing1 : IThing { }
    class Thing2 : IThing { }
    interface IThingControl<T> where T : IThing { }
    class ThingControl<Thing> { }
    class Module : NinjectModule {
        public override void Load()
        {
            Bind(typeof(IThingControl<>)).To(typeof(ThingControl<>));
        }
    }
    [TestFixture]
    public class SomewhereInCode
    {
        [Test]
        public void AddControls()
        {
            IKernel kernel = new StandardKernel(new Module());
            List<IThing> things = new List<IThing> { new Thing1(), new Thing2() };
            Type baseType = typeof(IThingControl<>);
            foreach (IThing thing in things)
            {
                Type type = baseType.MakeGenericType(thing.GetType());
                dynamic control = kernel.Get(type);
                Assert.That(
                    control is IThingControl<IThing>,
                    Is.False);
            }
        }
    }
