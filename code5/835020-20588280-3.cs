    using System;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Win32.Fakes;
    using WpfApplication1;
        [TestMethod]
        public void SomeTest()
        {
            using (var context = ShimsContext.Create())
            {
                Nullable<bool> b2 = true;
                ShimCommonDialog.AllInstances.ShowDialog = (x) => b2;
                var sut = new Sut();
                var r = sut.SomeMethod();
                Assert.IsTrue(r);
            }
        }
