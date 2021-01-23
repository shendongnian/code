    using System;
    namespace SynchronizingCollection.Server.Repository
    {
        /// <summary>
        /// To send changes in the repo
        /// </summary>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="T"></typeparam>
        public class OnChangedArgs<TK,T> : EventArgs
        {
            public Operation Operation { get; set; }
            public TK Key { get; set; }
            public T Value { get; set; }
        }
    }
    namespace SynchronizingCollection.Server.Repository
    {
        /// <summary>
        /// What kind of change was performed
        /// </summary>
        public enum Operation
        {
            AddUpdate,
            Remove
        }
    }
