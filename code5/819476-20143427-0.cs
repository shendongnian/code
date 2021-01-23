    /// <summary>
    /// Adds a sequence of parameters to an existing parameter collection
    /// </summary>
    /// <typeparam name="T">Type of parameter values</typeparam>
    /// <param name="parameters">Existing parameter collection</param>
    /// <param name="pattern">Name pattern of parameters. Must be a valid <see langword="int"/> format string</param>
    /// <param name="parameterType">Database type of parameters</param>
    /// <param name="length">Length of parameter. 0 for numeric parameters</param>
    /// <param name="values">Sequence of values</param>
    /// <returns>Comma separated string of parameter names</returns>
    public static string AddParameters<T>(SqlParameterCollection parameters,
                                          string pattern,
                                          SqlDbType parameterType,
                                          int length,
                                          IEnumerable<T> values) {
        if (parameters == null)
            throw new ArgumentNullException("parameters");
        if (pattern == null)
            throw new ArgumentNullException("pattern");
        if (values == null)
            throw new ArgumentNullException("values");
        if (!pattern.StartsWith("@", StringComparison.CurrentCultureIgnoreCase))
            throw new ArgumentException("Pattern must start with '@'");
        var parameterNames = new List<string>();
        foreach (var item in values) {
            var parameterName = parameterNames.Count.ToString(pattern, CultureInfo.InvariantCulture);
            parameterNames.Add(parameterName);
            parameters.Add(parameterName, parameterType, length).Value = item;
        }
        return string.Join(",", parameterNames.ToArray());
    }
