    public class Person : EntityBase<int>
    {
        #region Properties
        /// <summary>
        ///     Gets or sets the id of the entity.
        /// </summary>
        [Key]
        public TKey Id { get; set; }
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///     Gets or sets the firstname.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        ///     Gets or sets the <see cref="Manager"/>.
        /// </summary>
        public Manager Manager { get; set; }
        #endregion
    }
