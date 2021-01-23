    // Primary Key
    <#
        if (efHost.EntityType.KeyMembers.Count() == 1)
        {
    #>
                this.HasKey(t => t.<#= efHost.EntityType.KeyMembers.Single().Name #>)
    			.Property(t => t.<#= efHost.EntityType.KeyMembers.Single().Name #>).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
