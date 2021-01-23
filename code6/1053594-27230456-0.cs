    using System;
    using System.Diagnostics.Contracts;
             
    namespace Demo
    {
        [ContractClass(typeof(CanAddContract))]
        public interface ICanAdd
        {
            void Add(object entity);
        }
        [ContractClassFor(typeof (ICanAdd))]
        internal abstract class CanAddContract: ICanAdd
        {
            public void Add(object entity)
            {
                Contract.Requires(entity != null);
            }
        }
        [ContractClass(typeof(CanDeleteContract))]
        public interface ICanDelete
        {
            void Delete(object entity);
        }
        [ContractClassFor(typeof(ICanDelete))]
        internal abstract class CanDeleteContract: ICanDelete
        {
            public void Delete(object entity)
            {
                Contract.Requires(entity != null);
            }
        }
        [ContractClass(typeof(EntityStoreContract))]
        public interface IEntityStore: ICanAdd, ICanDelete
        {
            void SomeOtherMethodThatNeedsAContract(object entity);
        }
        // Note how we only specify the additional contract for SomeOtherMethodThatNeedsAContract().
        // We do NOT need to repeat the contracts for ICanAdd and ICanDelete.
        // These contracts are automatically inferred from the ICanAdd and ICanDelete contracts.
        [ContractClassFor(typeof(IEntityStore))]
        internal abstract class EntityStoreContract: IEntityStore
        {
            public void SomeOtherMethodThatNeedsAContract(object entity)
            {
                Contract.Requires(entity != null);
            }
            public abstract void Add(object entity);
            public abstract void Delete(object entity);
        }
        public sealed class EntityStore: IEntityStore
        {
            public void Add(object entity)
            {
            }
            public void Delete(object entity)
            {
            }
            public void SomeOtherMethodThatNeedsAContract(object entity)
            {
            }
        }
        public static class Program
        {
            private static void Main()
            {
                var entityStore = new EntityStore();
                entityStore.Add(null); // This will correctly give a code contracts exception.
            }
        }
    }
