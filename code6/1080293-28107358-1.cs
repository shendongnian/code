    [TestFixture]
    public class ObjectEqualsTests
    {
        [Test]
        public void CollectionAddRemoveEntityTest()
        {
            const int id = 12345;
            var list = new List<MyObject>();
            var firstObject = Substitute.For<MyObject>();
            firstObject.Id.Returns(id);
            list.Add(firstObject);
            Assert.IsTrue(list.Contains(firstObject), "Cannot find the first object");
            var secondObjectWithSameId = Substitute.For<MyObject>();
            secondObjectWithSameId.Id.Returns(id);
            Assert.IsTrue(list.Contains(secondObjectWithSameId), "Cannot find the second object");
            list.Remove(secondObjectWithSameId);
            Assert.AreEqual(0, list.Count, "Object was not removed from the list");
        }
    }
    public class MyObject : EntityBase<int>
    {
        public virtual string SomeProperty { get; set; }
    }
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
    public class EntityBase<TId> : IEntity<TId>
    {
        public virtual TId Id { get; protected set; }
        public override bool Equals(object other)
        {
            EntityBase<TId> otherEntity = other as EntityBase<TId>;
            if ((object)otherEntity == null)
            {
                return false;
            }
            return Equals(otherEntity);
        }
        public bool Equals(EntityBase<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (!IsTransient(this) && !IsTransient(other) && Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxfiedType();
                var thisType = GetUnproxfiedType();
                return thisType.IsAssignableFrom(otherType) && otherType.IsAssignableFrom(thisType);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Equals(Id, default(TId)) ? base.GetHashCode() : Id.GetHashCode();
        }
        private Type GetUnproxfiedType()
        {
            return GetType();
        }
        private static bool IsTransient(EntityBase<TId> obj)
        {
            return obj != null && Equals(obj.Id, default(TId));
        }
    }
