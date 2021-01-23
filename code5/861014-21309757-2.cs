    {
        IEnumerator e = ((IEnumerable)(queue)).GetEnumerator();
        try {
            Sometype someTypeObject;
            while (e.MoveNext()) {
                someTypeObject = (Sometype)e.Current;
                // loop body
           }
        }
        finally {
            // Dispose e
        }
    }
