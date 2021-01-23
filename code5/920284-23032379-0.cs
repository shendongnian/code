    {
        E e = ((C)(x)).GetEnumerator();
        try {
            while (e.MoveNext()) {
                V v = (V)(T)e.Current; // <-- double cast. For what?
                embedded-statement
            }
        }
        finally {
            … // Dispose e
        }
    }
