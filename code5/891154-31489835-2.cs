    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    // ReSharper disable PossibleInvalidOperationException
    // ReSharper disable once CheckNamespace
    namespace System
    {
        public class SettableConverter : JsonConverter
        {
            /// <summary>
            /// Simple interface implemented by
            /// strongly typed converters.
            /// </summary>
            public interface ITypedConverter
            {
                /// <summary>
                /// Converts a boxed value into a Settable
                /// instance and returns it.
                /// </summary>
                /// <param name="value"></param>
                /// <returns></returns>
                object Deserialize(object value);
                /// <summary>
                /// Extracts a value 
                /// </summary>
                /// <param name="value"></param>
                /// <returns></returns>
                object ExtractValue(object value);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class TypedConverter<T> : ITypedConverter
                where T : struct
            {
                public object Deserialize(object value)
                {
                    if (value == null)
                        return (Settable<T>)null;
                    try
                    {
                        var settedValue = (T)Convert.ChangeType(value, typeof(T));
                        return (Settable<T>) settedValue;
                    }
                    catch (Exception)
                    {
                        return (Settable<T>)null;
                    }
                }
                public object ExtractValue(object value)
                {
                    return (T?) ((Settable<T>) value);
                }
            }
            private static readonly Dictionary<Type, ITypedConverter> Converters = new Dictionary<Type, ITypedConverter>(); 
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var converter = GetConverter(value.GetType());
                serializer.Serialize(writer, converter.ExtractValue(value));
            }
            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param>
            /// <param name="objectType">Type of the object.</param>
            /// <param name="existingValue">The existing value of object being read.</param>
            /// <param name="serializer">The calling serializer.</param>
            /// <returns>
            /// The object value.
            /// </returns>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var converter = GetConverter(objectType);
                return converter.Deserialize(reader.Value);
            }
            private ITypedConverter GetConverter(Type objectType)
            {
                if (!Converters.ContainsKey(objectType))
                {
                    var valueType = ResolveSettableTypeParameter(objectType);
                    Converters[objectType] = Activator.CreateInstance(typeof(TypedConverter<>).MakeGenericType(valueType)) as ITypedConverter;
                }
                return Converters[objectType];
            }
            private Type ResolveSettableTypeParameter(Type settableType)
            {
                var toCheck = settableType;
                while (toCheck != null && toCheck != typeof(object))
                {
                    var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                    if (typeof(Settable<>) == cur)
                    {
                        return toCheck.GetGenericArguments().Single();
                    }
                    toCheck = toCheck.BaseType;
                }
                return null;
                // throw new InvalidOperationException("The provided type " + settableType.FullName + " does not inherit from Settable<T>");
            }
            
            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns>
            /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
            /// </returns>
            public override bool CanConvert(Type objectType)
            {
                return Converters.ContainsKey(objectType) || ResolveSettableTypeParameter(objectType) != null;
            }
        }
        /// <summary>
        /// Struct wrapping a nullable type.
        /// The main distinction point between
        /// Settable and Nullable is the IsSet
        /// property, which is false for the default value,
        /// but true if an explicit value has been specified
        /// (evev if it is null).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [JsonConverter(typeof(SettableConverter))]
        public struct Settable<T> where T : struct
        {
            /// <summary>
            /// Returns the default value for this struct,
            /// which represents an undefined value;
            /// </summary>
            public static Settable<T> Undefined { get { return default(Settable<T>); } }
            private T _value;
            private bool _isSet;
            private bool _hasValue;
            /// <summary>
            /// Standard constructor.
            /// </summary>
            /// <param name="value"></param>
            public Settable(T? value)
            {
                _isSet = true;
                _hasValue = value.HasValue;
                _value = _hasValue ? value.Value : default(T);
            }
            /// <summary>
            /// True if a value has been set, even if it is null.
            /// </summary>
            public bool IsSet
            {
                get { return _isSet; }
            }
            /// <summary>
            /// True if not null or undefined.
            /// </summary>
            public bool HasValue
            {
                get { return _isSet && _hasValue; }
            }
            /// <summary>
            /// Gets the value of the current <see cref="Settable{T}"/>. 
            /// </summary>
            public T Value
            {
                get
                {
                    if (_isSet && _hasValue)
                        return _value;
                    throw new InvalidOperationException("The value is null or undefined.");
                }
                set {
                    _isSet = true;
                    _hasValue = true;
                    _value = value;
                }
            }
            /// <summary>
            /// Conversion from Nullable
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static implicit operator Settable<T>(T? value)
            {
                var s = new Settable<T>
                {
                    _isSet = true,
                    _hasValue = value.HasValue
                };
                if (value.HasValue) s._value = value.Value;
                return s;
            }
            /// <summary>
            /// Conversion from value type.
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static implicit operator Settable<T>(T value)
            {
                return new Settable<T>
                {
                    _isSet = true,
                    _hasValue = true,
                    _value = value
                };
            }
            /// <summary>
            /// Conversion to nullable.
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static implicit operator T?(Settable<T> value)
            {
                return (value.HasValue) ? (T?)value._value : null;
            }
            /// <summary>
            /// Conversion to nullable.
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public static implicit operator T(Settable<T> value)
            {
                if (value.HasValue)
                    return value._value;
                throw new InvalidOperationException("Cannot convert null or undefined values.");
            }
            public T GetValueOrDefault()
            {
                return _value;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="defaultValue"></param>
            /// <returns></returns>
            public T GetValueOrDefault(T defaultValue)
            {
                if (!HasValue)
                    return defaultValue;
                
                return _value;
            }
            public override bool Equals(object other)
            {
                if (!HasValue)
                    return other == null;
                if (other == null)
                    return false;
                return _value.Equals(other);
            }
            /// <summary>
            /// Implementation of the equals operator.
            /// </summary>
            /// <param name="t1"></param>
            /// <param name="t2"></param>
            /// <returns></returns>
            public static bool operator ==(Settable<T> t1, Settable<T> t2)
            {
                // undefined equals undefined
                if (!t1._isSet && !t2.IsSet) return true;
                // undefined != everything else
                if (t1._isSet ^ t2._isSet) return false;
                // null equals null
                if (!t1._hasValue && !t2._hasValue) return true;
                // null != everything else
                if (t1._hasValue ^ t2._hasValue) return false;
                // if both are values, compare them
                return t1._value.Equals(t2._value);
            }
            /// <summary>
            /// Implementation of the inequality operator.
            /// </summary>
            /// <param name="t1"></param>
            /// <param name="t2"></param>
            /// <returns></returns>
            public static bool operator !=(Settable<T> t1, Settable<T> t2)
            {
                return !(t1 == t2);
            }
            public override int GetHashCode()
            {
                if (!_isSet) return -1;
                if (!_hasValue) return 0;
                return _value.GetHashCode();
            }
            public override string ToString()
            {
                return HasValue ? _value.ToString() : String.Empty;
            }
        }
    }
