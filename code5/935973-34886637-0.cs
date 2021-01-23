        public class AssertHelper
        {
            public static void HasEqualFieldValues<T>(T expected, T actual)
            {
                var failures = new List<string>();
                var fields = typeof(T).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                foreach(var field in fields)
                {
                    var v1 = field.GetValue(expected);
                    var v2 = field.GetValue(actual);
                    if (v1 == null && v2 == null) continue;
                    if(!v1.Equals(v2)) failures.Add(string.Format("{0}: Expected:<{1}> Actual:<{2}>", field.Name, v1, v2));
                }
                if (failures.Any())
                    Assert.Fail("AssertHelper.HasEqualFieldValues failed. " + Environment.NewLine+ string.Join(Environment.NewLine, failures));
            }
        }
        [TestClass]
        public class AssertHelperTests
        {
            [TestMethod]     
            [ExpectedException(typeof(AssertFailedException))]           
            public void ShouldFailForDifferentClasses()
            {            
                var actual = new NewPaymentEntry() { acct = "1" };
                var expected = new NewPaymentEntry() { acct = "2" };
                AssertHelper.HasEqualFieldValues(expected, actual);
            }
        }
