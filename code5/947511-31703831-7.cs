	this.Property(t => t.PropertyTwo)
		.HasColumnAnnotation(
			IndexAnnotation.AnnotationName,
			new IndexAnnotation(new[] 
				{
					new IndexAttribute(), // This is the index
					new IndexAttribute(uniqueIndex) // This is the Unique made earlier
					{
						IsUnique = true,
						Order = 2
					}
				}
			)
		);
