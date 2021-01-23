    public void Should_return_null_if_assembly_does_not_reference_anything(){ 
        var result = YourFunctionToTest(yourEmptyDummyAssembly);
        ... 
        // Check result in a suitable way
    }
    public void Should_return_expected_assemblies(){
        var result = YourFunctionToTest(otherDummyAssembly);
        ... 
        // Check result in a suitable way
    }
    // etc...
