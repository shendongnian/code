    [TestFixture]
    public class FormsTests
    {
        #region Public Methods and Operators
        [TestCase(null, null, null, 1000)]
        [TestCase("Kim", null, null, 500)]
        [TestCase("Kim", null, "Akers", 250)]
        [TestCase("Kim", "B", "Abercrombie", 100)]
        public void InsuredSearcherResponseTimeWithReflectionTest(string firstName, string middleName, string lastName, long milliseconds)
        {
            var monitor = new SemaphoreSlim(1);
            monitor.Wait();
            var form = new Insured();
            form.SetControlProperty<TextBox>("tbFirstName", "Text", firstName);
            form.SetControlProperty<TextBox>("tbMiddleName", "Text", middleName);
            form.SetControlProperty<TextBox>("tbLastName", "Text", lastName);
            form.ObserveControlEvents<DataGridView>(
                "dataGridView1",
                "DataSourceChanged",
                (sender, args) =>
                {
                    Trace.WriteLine("Occured in delegate");
                    monitor.Release();
                });
            Trace.WriteLine("Executing");
            var sw = form.ClickButton("btnSearch");
            monitor.Wait();
            sw.Stop();
            Trace.WriteLine(String.Format("Row count was {0} took {1}ms to process", form.GetControlProperty<DataGridView>("dataGridView1", "RowCount"), sw.ElapsedMilliseconds));
            Assert.IsTrue(sw.ElapsedMilliseconds < milliseconds);
        }
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            var monitor = new SemaphoreSlim(1);
            monitor.Wait();
            var form = new Insured();
            form.ObserveControlEvents<DataGridView>(
                "dataGridView1",
                "DataSourceChanged",
                (sender, args) =>
                {
                    Trace.WriteLine("Occured in delegate");
                    monitor.Release();
                });
            form.ClickButton("btnSearch");
            monitor.Wait();
        }
    }
