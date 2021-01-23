    /// <summary>
    /// Initializes a new instance of the <see cref="ValuesController"/> class.
    /// </summary>
    /// <param name="valuesProvider">The values provider.</param>
    public Values2Controller(IKernel kernel)
    {
        this.valuesProvider1 = kernel.Get<IValuesProvider>();
        this.valuesProvider2 = kernel.Get<IValuesProvider>();
    }
