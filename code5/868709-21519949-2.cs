        public interface HasJson
        {
            string ToJson();
        }
        public static class ObjectHelper<TIn, TOut>
            where TIn : HasJson // now you can call ToJson() method on type TIn
