    public DHParameters GenerateParameters()
    {
        var generator = new DHParametersGenerator();
        generator.Init(BitSize, DefaultPrimeProbability, new SecureRandom());
        return generator.GenerateParameters();
    }
