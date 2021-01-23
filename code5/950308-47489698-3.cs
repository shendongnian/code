    using NUnit.Framework;
    using System.Linq;
    //[Timeout(1000)]
    public class SubsetsTests
    {
        [Test]
        public void Compute0_1()
        {
            var act = new TestDelegate(() => Subsets.Compute(0, 1).ToArray());
            Assert.That(act, Throws.Exception);
        }
        [Test]
        public void Compute_1_0()
        {
            var act = new TestDelegate(() => Subsets.Compute(-1, 0).ToArray());
            Assert.That(act, Throws.Exception);
        }
        [Test]
        public void Compute1__1()
        {
            var act = new TestDelegate(() => Subsets.Compute(1, -1).ToArray());
            Assert.That(act, Throws.Exception);
        }
        [Test]
        public void Compute0_0()
        {
            var result = Subsets.Compute(0, 0).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new int[0]));
        }
        [Test]
        public void Compute1_1()
        {
            var result = Subsets.Compute(1, 1).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0 }));
        }
        [Test]
        public void Compute1_0()
        {
            var result = Subsets.Compute(1, 0).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new int[0]));
        }
        [Test]
        public void Compute2_2()
        {
            var result = Subsets.Compute(2, 2).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1 }));
        }
        [Test]
        public void Compute2_1()
        {
            var result = Subsets.Compute(2, 1).ToArray();
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 1 }));
        }
        [Test]
        public void Compute2_0()
        {
            var result = Subsets.Compute(2, 0).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new int[0]));
        }
        [Test]
        public void Compute3_3()
        {
            var result = Subsets.Compute(3, 3).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1, 2 }));
        }
        [Test]
        public void Compute3_2()
        {
            var result = Subsets.Compute(3, 2).ToArray();
            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 0, 2 }));
            Assert.That(result[2], Is.EquivalentTo(new[] { 1, 2 }));
        }
        [Test]
        public void Compute3_1()
        {
            var result = Subsets.Compute(3, 1).ToArray();
            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 1 }));
            Assert.That(result[2], Is.EquivalentTo(new[] { 2 }));
        }
        [Test]
        public void Compute3_0()
        {
            var result = Subsets.Compute(2, 0).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new int[0]));
        }
        [Test]
        public void Compute4_4()
        {
            var result = Subsets.Compute(4, 4).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1, 2, 3 }));
        }
        [Test]
        public void Compute4_3()
        {
            var result = Subsets.Compute(4, 3).ToArray();
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1, 2 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 0, 1, 3 }));
            Assert.That(result[2], Is.EquivalentTo(new[] { 0, 2, 3 }));
            Assert.That(result[3], Is.EquivalentTo(new[] { 1, 2, 3 }));
        }
        [Test]
        public void Compute4_2()
        {
            var result = Subsets.Compute(4, 2).ToArray();
            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 0, 2 }));
            Assert.That(result[2], Is.EquivalentTo(new[] { 0, 3 }));
            Assert.That(result[3], Is.EquivalentTo(new[] { 1, 2 }));
            Assert.That(result[4], Is.EquivalentTo(new[] { 1, 3 }));
            Assert.That(result[5], Is.EquivalentTo(new[] { 2, 3 }));
        }
        [Test]
        public void Compute4_1()
        {
            var result = Subsets.Compute(4, 1).ToArray();
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 1 }));
            Assert.That(result[2], Is.EquivalentTo(new[] { 2 }));
            Assert.That(result[3], Is.EquivalentTo(new[] { 3 }));
        }
        [Test]
        public void Compute5_5()
        {
            var result = Subsets.Compute(5, 5).ToArray();
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1, 2, 3, 4 }));
        }
        [Test]
        public void Compute5_4()
        {
            var result = Subsets.Compute(5, 4).ToArray();
            Assert.That(result.Length, Is.EqualTo(5));
            Assert.That(result[0], Is.EquivalentTo(new[] { 0, 1, 2, 3 }));
            Assert.That(result[1], Is.EquivalentTo(new[] { 0, 1, 2, 4 }));
            Assert.That(result[2], Is.EquivalentTo(new[] { 0, 1, 3, 4 }));
            Assert.That(result[3], Is.EquivalentTo(new[] { 0, 2, 3, 4 }));
            Assert.That(result[4], Is.EquivalentTo(new[] { 1, 2, 3, 4 }));
        }
        [Test]
        public void Compute5_3()
        {
            var result = Subsets.Compute(5, 3).ToArray();
            Assert.That(result.Length, Is.EqualTo(10));
            var i = 0;
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 1, 2 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 1, 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 1, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 2, 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 2, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 3, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1, 2, 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1, 2, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1, 3, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 2, 3, 4 }));
        }
        [Test]
        public void Compute5_2()
        {
            var result = Subsets.Compute(5, 2).ToArray();
            Assert.That(result.Length, Is.EqualTo(10));
            var i = 0;
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 1 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 2 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1, 2 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1, 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 2, 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 2, 4 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 3, 4 }));
        }
        [Test]
        public void Compute5_1()
        {
            var result = Subsets.Compute(5, 1).ToArray();
            Assert.That(result.Length, Is.EqualTo(5));
            var i = 0;
            Assert.That(result[i++], Is.EquivalentTo(new[] { 0 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 1 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 2 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 3 }));
            Assert.That(result[i++], Is.EquivalentTo(new[] { 4 }));
        }
    }
