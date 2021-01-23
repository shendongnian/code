    class GeneratedClass
    {
    
        use GeneratedTrait;
    
        // auto generated stuff
    
    }
    
    trait GeneratedTrait
    {
    
        // empty
    
    }
    
    function generateClass(Definition $d)
    {
        if (!generatedTraitExists($d))
        {
            generateTrait($d);
        }
        // generate the class
    }
