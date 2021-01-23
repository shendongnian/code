    public interface Parameter {
        // getters and setters as before
        public boolean contain(this List<Parameter> parameters, String key)
        default {
            for (Parameter parameter : parameters) {
                if (parameter.getKey().equals(key)) { 
                     return true; 
                } 
            }
            return false;
        }
    }
