    [TestClass]
    public class NotifyingHashSetTests
    {
        [TestMethod]
        public void ShouldAddToNotifyingHashSet()
        {
            var notifyingHashSet = new NotifyingHashSet<int>();
            notifyingHashSet.ItemAdded += (sender, changed) => Assert.AreEqual(changed.ChangedItem, 1);
            notifyingHashSet.Add(1);
        }
        [TestMethod]
        public void ShouldRemoveFromNotifyingHashSet()
        {
            //can use collection initializer
            var notifyingHashSet = new NotifyingHashSet<int> { 1 };
            notifyingHashSet.ItemRemoved += (sender, changed) => Assert.AreEqual(changed.ChangedItem, 1);
            notifyingHashSet.Remove(1);
        }        
        
        [TestMethod]
        public void ShouldContainValueInNotifyingHashSet()
        {
            //can use collection initializer
            var notifyingHashSet = new NotifyingHashSet<int> { 1 };
            Assert.IsTrue(notifyingHashSet.Contains(1));
        }
        [TestMethod]
        public void ShouldAssignToHashSet()
        {
            HashSet<int> notifyingHashSet = new NotifyingHashSet<int> { 1 };
            Assert.IsTrue(notifyingHashSet.IsSubsetOf(new List<int>{ 1,2 }));
        }
    }
