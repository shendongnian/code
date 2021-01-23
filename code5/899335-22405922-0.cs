    public class TestClass {
        private TestClass() { }
    }
    var t = typeof(TestClass);
    var ci = t.GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        new Type[0],
        null
    );
    var myTestClassObject = (TestClass)ci.Invoke(null);
