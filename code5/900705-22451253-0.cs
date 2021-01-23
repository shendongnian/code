    public static class RazorExtensions {
        public static HelperResult List<T>(this IEnumerable<T> items, 
          Func<T, HelperResult> template) {
            return new HelperResult(writer => {
                foreach (var item in items) {
                    template(item).WriteTo(writer);
                }
            });
        }
    }
