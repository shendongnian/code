    public static class ExtensionMethods
    {
        public static StringPropertyConfiguration HasIndex(this StringPropertyConfiguration config, string indexName, int i)
        {
            return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation((new IndexAttribute(indexName, i) { IsUnique = true })));
        }
        public static PrimitivePropertyConfiguration HasIndex(this PrimitivePropertyConfiguration config, string indexName, int i)
        {
            return config.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation((new IndexAttribute(indexName, i) { IsUnique = true })));
        }
    }
