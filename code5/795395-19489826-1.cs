    {
    	E e = ((C)(x)).GetEnumerator();
    	try {
    		while (e.MoveNext()) {
    			V v = (V)(T)e.Current; //explicit cast
    			embedded-statement
    		}
    	}
    	finally {
    		… // Dispose e
    	}
    }
