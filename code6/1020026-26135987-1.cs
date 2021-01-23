    public class ContactoMap : EntityTypeConfiguration<Contacto>
    {
        public ContactoMap()
        {
            ToTable("tblContacto");
            Property(c => c.ProveedorID).HasColumnName("ProveedorId");
            HasRequired(x => x.Proveedor).WithMany().HasForeignKey(c => c.ProveedorID);
            Property(c => c.UsuarioID).HasColumnName("UsuarioId");
            HasRequired(x => x.Usuario).WithMany().HasForeignKey(c => c.UsuarioID);
        }
    }
