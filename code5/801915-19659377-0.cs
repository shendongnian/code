     <member name="T:JetBrains.Annotations.NotNullAttribute">
         <summary>
         Indicates that the value of the marked element could never be <c>null</c>
         </summary>
         <example><code>
         [NotNull] public object Foo() {
           return null; // Warning: Possible 'null' assignment
         }
         </code></example>
     </member>
