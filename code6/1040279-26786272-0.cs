     namespace MvcApplication1.Helpers
    {
    public class ModelValueListProvider : IEnumerable<SelectListItem>
    {
        List<KeyValuePair<string, string>> innerList = new List<KeyValuePair<string, string>>();
        public static readonly ModelValueListProvider PostTypeList = new PostTypeListProvider();
        public static ModelValueListProvider MethodAccessEnumWithRol(int id)
        {
            return new PostTypeListProvider(null, id);
        }
        protected void Add(string value, string text)
        {
            string innerValue = null, innerText = null;
            if (value != null)
                innerValue = value.ToString();
            if (text != null)
                innerText = text.ToString();
            if (innerList.Exists(kvp => kvp.Key == innerValue))
                throw new ArgumentException("Value must be unique", "value");
            innerList.Add(new KeyValuePair<string, string>(innerValue, innerText));
        }
        public IEnumerator<SelectListItem> GetEnumerator()
        {
            return new ModelValueListProviderEnumerator(innerList.GetEnumerator());
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private struct ModelValueListProviderEnumerator : IEnumerator<SelectListItem>
        {
            private IEnumerator<KeyValuePair<string, string>> innerEnumerator;
            public ModelValueListProviderEnumerator(IEnumerator<KeyValuePair<string, string>> enumerator)
            {
                innerEnumerator = enumerator;
            }
            public SelectListItem Current
            {
                get
                {
                    var current = innerEnumerator.Current;
                    return new SelectListItem { Value = current.Key, Text = current.Value };
                }
            }
            public void Dispose()
            {
                try
                {
                    innerEnumerator.Dispose();
                }
                catch (Exception)
                {
                }
            }
            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public bool MoveNext()
            {
                return innerEnumerator.MoveNext();
            }
            public void Reset()
            {
                innerEnumerator.Reset();
            }
        }
        private class PostTypeListProvider : ModelValueListProvider
        {
            public PostTypeListProvider(string defaultText = null, int rolId = 0)
            {
                if (!string.IsNullOrEmpty(defaultText))
                    Add(string.Empty, defaultText);
                if (rolId == 1)
                    Add(PostType.PostType1, "PostType1");
                else
                {
                    Add(PostType.PostType2, "PostType2");
                    Add(PostType.PostType3, "PostType3");
                    Add(PostType.PostType4, "PostType4");
                    Add(PostType.PostType5, "PostType5");
                    Add(PostType.PostType6, "PostType6");
                }
            }
            public void Add(PostType value, string text)
            {
                Add(value.ToString("d"), text);
            }
        }
    }
      public enum PostType
       {
        PostType1,
        PostType2,
        PostType3,
        PostType4,
        PostType5,
        PostType6
        }
      }
