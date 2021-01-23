        /// <summary>
        /// Converts search to raw JSON request for debugging.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="self">The self.</param>
        /// <param name="searchDescriptor">The search descriptor.</param>
        /// <returns>The string.</returns>
        public static string ToRawRequest<T>(this IElasticClient self, SearchDescriptor<T> searchDescriptor) where T : class
        {
            using (var output = new MemoryStream())
            {
                self.Serializer.Serialize(searchDescriptor, output);
                output.Position = 0;
                var rawQuery = new StreamReader(output).ReadToEnd();
                return rawQuery;
            }
        }
        /// <summary>
        /// Prints query into string.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>The value.</returns>
        public static string ToPrettyString(this QueryContainer self)
        {
            using (var settings = new ConnectionSettings())
            {
                var visitor = new DslPrettyPrintVisitor(settings);
                self.Accept(visitor);
                return visitor.PrettyPrint.Replace(Environment.NewLine, string.Empty);
            }                                                                         
        }
