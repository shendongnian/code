    private static HashSet<Type> _values = new HashSet<Type> { Type.TYPE_1, Type.TYPE_2, Type.TYPE_3, Type.TYPE_4 };
    public void Validate(Type type) {
        if(!_values.Contains(type)) {
            //do something
        }
    }
