    public static bool IsNullOrEmpty(object obj) {
      ICollection c = obj as ICollection;
      if (c != null) {
        return c.Count == 0;
      }
      IEnumerable e = obj as IEnumerable;
      if (e != null) {
        return !e.GetEnumerator().MoveNext();
      }
      return false;
    }
