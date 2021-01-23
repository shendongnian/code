    /// <summary>
    /// Specify that this entity should use a discriminator with it's subclasses.
    /// This is a mapping strategy called table-per-inheritance-hierarchy; where all
    /// subclasses are stored in the same table, differenciated by a discriminator
    /// column value.
    /// </summary>
    /// <typeparam name="TDiscriminator">Type of the discriminator column</typeparam>
    /// <param name="columnName">Discriminator column name</param>
    /// <param name="baseClassDiscriminator">Default discriminator value</param>
    public DiscriminatorPart DiscriminateSubClassesOnColumn<TDiscriminator>(
        string columnName, TDiscriminator baseClassDiscriminator)
