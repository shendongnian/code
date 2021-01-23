    public class UsuariosConfiguracion : EntityTypeConfiguration<tblUsuarios>
         {
        public UsuariosConfiguracion()
        {
            //Relacion uno a uno. Un alumno un Usuarios.
            this.HasRequired(u => u.objAlumno)
                .WithRequiredPrincipal(a => a.objUsuario);
                .Map(p => p.MapKey("AlumnoID")); // <<< Right HERE  
          }
       }
