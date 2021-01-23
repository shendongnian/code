    public struct Step {
        public Func<dynamic, dynamic> Path;
        public Type ExpectedType;
    }
    public static class StructureHelper {
        public static T Traverse<T>(dynamic obj, Step[] steps) {
            dynamic current = obj;
            for (int i = 0; i < steps.Length; i++) {
                if (current == null)
                    return default(T);
                dynamic next = steps[i].Path(current);
                if (next.GetType() != steps[i].ExpectedType)
                    return default(T);
                current = next;
            }
            if (current.GetType() == typeof(T))
                return (T)current;
            else
                return default(T);
        }
    }
