    class GlobalClass {
    }
    namespace MyNamespace {
        class NameSpaceClass {
            public NameSpaceClass() {
                var globalObj = new global::GlobalClass();
            }
        }
    }
