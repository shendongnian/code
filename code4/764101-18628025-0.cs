    using System;
    /// <summary>
    /// Class representing a single source for domain events within an application.
    /// </summary>
    public class DomainEventSource
    {
        #region Fields
        private static readonly Lazy<DomainEventSource> source = new Lazy<DomainEventSource>( () => new DomainEventSource() );
        #endregion
        #region Properties
        /// <summary>
        /// Gets a reference to the singleton instance of the <see cref="DopmainEventSource"/> class.
        /// </summary>
        /// <value> A<see cref="DomainEventSource"/> object.</value>
        public static DomainEventSource Instance
        {
            get
            {
                return source.Value;
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Method called to indicate an event should be triggered with a given item name.
        /// </summary>
        /// <param name="name">A <see cref="string"/> value.</param>
        public void FireEvent( string name )
        {
            if ( this.AddItem != null )
            {
                this.AddItem( source, new AddItemEvent( name ) );
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// Event raised when add item is needed.
        /// </summary>
        public EventHandler<AddItemEvent> AddItem;
        #endregion
    }
