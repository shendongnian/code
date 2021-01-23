    using System;
    using System.Globalization;
    public class Stackoverflow<T>
    {
        private static Func<IConvertible, IFormatProvider, T> convertValue = (a, b) =>
        {
            throw new Exception("Initialize must be called to initialize the operations");
        };
        private static Func<T, T, T> op = (a, b) =>
            {
                throw new Exception("Initialize must be called to initialize the operations");
            };
        public static void Initialize(Func<IConvertible, IFormatProvider, T> ToGenericValue, Func<T, T, T> opGeneric)
        {
            convertValue = ToGenericValue;
            op = opGeneric;
        }
        public static T Operation<K>(K a, K b) where K : IConvertible
        {
            T aAsT = convertValue(a, CultureInfo.InvariantCulture);
            T bAsT = convertValue(b, CultureInfo.InvariantCulture);
            return op(aAsT, bAsT);
        }
    }
