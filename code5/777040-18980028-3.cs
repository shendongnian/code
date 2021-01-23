    public interface Parameter {
        // getters and setters as before
        public default boolean contain(this List<Parameter> parameters, String key) {
            // (Do not copy this!  There are better ways to code this in Java 8 ...
            //  ... but that is beside the point.)
            for (Parameter parameter : parameters) {
                if (parameter.getKey().equals(key)) { 
                     return true; 
                } 
            }
            return false;
        }
    }
