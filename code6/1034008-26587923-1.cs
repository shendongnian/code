    using System.ComponentModel.DataAnnotations.Schema; 
    using System.Data.Entity.Infrastructure.Annotations;
    ...
    
    this.Property(t => t.UserName) 
        .HasColumnAnnotation(
           IndexAnnotation.AnnotationName, 
           new IndexAnnotation(
               new IndexAttribute("IX_UserName", 1) { IsUnique = true }));
