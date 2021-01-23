    // C# 7.2+: Non-Trailing named arguments
    Throw.ArgumentNullException(when: param.IsNull(), nameof(param));
    // OR
    // Prior to C# 7.2: You can use a helper method 'When'
    Throw.ArgumentNullException(When(param.IsNull()), nameof(param));
    // OR
    Throw.ArgumentNullException(param == null, nameof(param));
    // OR
    Throw.ArgumentNullException(When (param == null), nameof(param));
