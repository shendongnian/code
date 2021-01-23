	string uniqueIndex = "UN_TableName";
	this.Property(t => t.PropertyOne)
		.HasColumnAnnotation(
			IndexAnnotation.AnnotationName,
			new IndexAnnotation(
				new IndexAttribute(uniqueIndex)
				{
					IsUnique = true,
					Order = 1
				}
			)
		);
	this.Property(t => t.PropertyTwo)
		.HasColumnAnnotation(
			IndexAnnotation.AnnotationName,
			new IndexAnnotation(
				new IndexAttribute(uniqueIndex)
				{
					IsUnique = true,
					Order = 2
				}
				
			)
		);
