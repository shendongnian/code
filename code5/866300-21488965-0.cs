    modelBuilder.Entity<Measurement>()
        .HasKey( ke => ke.MeasurementId )
        .Map( emc =>
        {
            emc.Properties( pe => new { pe.MeasurementId, pe.Name, pe.DeviceId } );
            emc.ToTable( "Measurement" );
        } )
        .Map( emc =>
        {
            emc.Properties( pe => new { pe.MeasurementId, pe.ParentId } );
            emc.ToTable( "Measurement_Parent" );
            // for this example's clarity I've named the PK Child_MeasurementId
            //  but in real-world use I would name it MeasurementId
            emc.Property( pe => pe.MeasurementId ).HasColumnName( "Child_MeasurementId" );
            emc.Property( pe => pe.ParentId ).HasColumnName( "Parent_MeasurementId" );
        } );
    modelBuilder.Entity<Measurement>()
        .HasOptional( npe => npe.Parent )
        .WithMany( npe => npe.Children )
        .HasForeignKey( fke => fke.ParentId );
