    HasRequired(a => a.ParentProduct)
                    .WithMany(b => b.ChildProducts)
                    .HasForeignKey(c => c.ParentId) // FK_RelatedProductParentID
                    .WillCascadeOnDelete(false);
    HasRequired(a => a.ChildProduct)
                    .WithMany(b => b.ParentProducts)
                    .HasForeignKey(c => c.ChildId); // FK_RelatedProductChildID
    public class CategoryDependency
        {
            [Key, Column(Order = 0)]
            public int ParentId { get; set; } // ParentID
            [Key, Column(Order = 1)]
            public int ChildId { get; set; } // ChildID
    
            // Foreign keys
            public virtual Product ParentProduct { get; set; } //  FK_RelatedProductParentID
            public virtual Product ChildProduct { get; set; } //  FK_RelatedProductChildID
        }
    public class Product
        {
            [Key]
            public int ProductId { get; set; } // ProductID (Primary key)
            public string ProductName { get; set; } // ProductName
            
    
            // Reverse navigation
            public virtual ICollection<RelatedProduct> ParentProducts { get; set; } // RelatedProduct.FK_RelatedProductChildID
            public virtual ICollection<RelatedProduct> ChildProducts { get; set; } // RelatedProduct.FK_RelatedProductParentID
        }
