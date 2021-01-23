        public interface HasJson
        {
            string ToJson();
        }
        public static class ObjectHelper<TIn, TOut>
            where TIn : HasJson // now you can call HasJson() method on type TIn
