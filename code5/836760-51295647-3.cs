    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    public static class ConvertUtil
    {
        /// <summary>
        /// Converts <paramref name="source"/> to type <typeparamref name="TResult"/> 
        /// using reflection to determine the appropriate explicit or implicit cast
        /// operator.
        /// </summary>
        /// <typeparam name="TResult">
        /// The Type to convert <paramref name="source"/> to.
        /// </typeparam>
        /// <param name="source">The object being converted.</param>
        /// <returns>
        /// <paramref name="source"/> cast as <typeparamref name="TResult"/>.
        /// </returns>
        /// <remarks>
        /// Detects the type of <paramref name="source"/> type at run time.  This is a
        /// minor performance hit if used frequently.
        /// </remarks>
        /// <exception cref="InvalidCastException" />
        public static TResult ConvertTo<TResult>(object source) where TResult : class
        {
            if (source == null || sosurce is TResult)
            {
                return source;
            }
            Type sourceType = source?.GetType();
            return (TResult)GetConverter(sourceType, typeof(TResult))?.Invoke(source) ??
                throw new InvalidCastException($"No implicit or explicit cast from type" +
                    $" {sourceType.Name} to {resultType.Name} exists.");
        }
        /// <summary>
        /// Converts <paramref name="source"/> to type <typeparamref name="TResult"/> 
        /// using reflection to determine the appropriate explicit or implicit cast
        /// operator.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type <paramref name="source"/> is being converted from.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The Type to convert <paramref name="source"/>
        /// to.
        /// </typeparam>
        /// <param name="source">The object being converted.</param>
        /// <returns>
        /// <paramref name="source"/> cast as <typeparamref name="TResult"/>.
        /// </returns>
        /// <remarks>
        /// Detects the type of <paramref name="source"/> type at compile time for a
        /// slight performance gain over <see cref="ConvertTo{TResult}(object)"/> if used
        /// frequently.
        /// </remarks>
        /// <exception cref="InvalidCastException" />
        public static TResult ConvertTo<TSource, TResult>(TSource source) 
            where TSource : class 
            where TResult : class
        {
            if (source == null || sosurce is TResult)
            {
                return source;
            }
            Func<object, object> converter = 
                GetConverter(typeof(TSource), typeof(TResult)) ??
                    throw new InvalidCastException($"No implicit or explicit cast from " +
                        $"type {sourceType.Name} to {resultType.Name} exists.");
            return (TResult)converter(source);
        }
        /// <summary>
        /// Lock for thread safety.  If this isn't an issue, you can remove this and all
        /// the <c>lock</c> portions of <see cref="GetConverter(Type, Type)"/>
        /// </summary>
        private static readonly object s_typeConvertersLock = new object();
        /// <summary>
        /// The map from source types to maps from destination types to their converting
        /// functions.
        /// </summary>
        private static readonly Dictionary<Type, Dictionary<Type, Func<object, object>>> s_typeConverters =
            new Dictionary<Type, Dictionary<Type, Func<object, object>>>();
        /// <summary>
        /// Retrieves the first implicit or explicit defined casting operator from
        /// <paramref name="sourceType"/> to <paramref name="resultType"/>.  Returns null
        /// if no such operator is defined.
        /// </summary>
        /// <param name="sourceType">The type being converted from.</param>
        /// <param name="resultType">The type being converted to.</param>
        /// <remarks>
        /// Only searches for the cast operator once per (<paramref name="sourceType"/>,
        /// <paramref name="resultType"/>) pair.
        /// </remarks>
        /// <returns>
        /// The first defined casting operator from <paramref name="sourceType"/> to
        /// <paramref name="resultType"/>. Null if no operator is defined.
        /// </returns>
        private static Func<object, object> GetConverter(Type sourceType, Type resultType)
        {
            // retrieve all the operators from sourceType that we know about if we know of
            // none, add an empty map to the dictionary
            if (!s_typeConverters.TryGetValue(sourceType, 
                    out Dictionary<Type, Func<object, object>> sourceConverters))
            {
                lock (s_typeConvertersLock)
                {
                    // check again in case another thread has already added the converter
                    // dictionary while waiting for the lock
                    if (!s_typeConverters.TryGetValue(sourceType, out sourceConverters))
                    {
                        sourceConverters = new Dictionary<Type, Func<object, object>>();
                        s_typeConverters.Add(sourceType, sourceConverters);
                    }
                }
            }
            // retrieve the operator from sourceType to resultType 
            // if we have not found it yet, search for it using reflection and add it to
            // the dictionary 
            // if no such cast operator exists, add still null to the dictionary so that
            // we don't need to search again
            if (!sourceConverters.TryGetValue(resultType, 
                    out Func<object, object> converter))
            {
                lock (s_typeConvertersLock)
                {
                    // check again in case another thread has already added the converter
                    // while waiting for the lock
                    if (!sourceConverters.TryGetValue(resultType, out castOperator))
                    {
                        var castOperator =
                            (from method in resultType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                             where (method.Name == "op_Explicit" | 
                                    method.Name == "op_Implicit") &&
                                 method.ReturnType == resultType
                             let paramInfo = method.GetParameters()
                             where paramInfo.Length == 1 && 
                                paramInfo[0].ParameterType == sourceType
                             select method).FirstOrDefault();
                        converter = 
                            source => castOperator?.Invoke(null, new object[] { source });
                        sourceConverters.Add(resultType, converter);
                    }
                }
            }
            return converter;
        }
    }
