    <#
        // The model defines *what* we like generated
        var model = new []
        {
            "ValidPercent"      ,
            "Percent"           ,
        };
    #>
    namespace TestProject
    {
    <#
        // The "View" defines *how* the model is transformed into code
        foreach (var cls in model)
        {
    #>
    
        partial struct <#=cls#>
        {
            // Partial struct/class are great with T4 or any code-generation tool
            decimal m_value;
            // Partial methods are great to inject customized behavior into the generated code skeleton
            static partial void Partial_ValidateValue (decimal value);
            public <#=cls#> (decimal value)
            {
                Partial_ValidateValue (value);
                m_value = value;
            }
            public decimal Value 
            {
                get
                {
                    return m_value;
                }
                set
                {
                    Partial_ValidateValue (value);
                    m_value = value;
                }
            }
            public override string ToString ()
            {
                return Value + "%";
            }
        }
    <#
        }
    #>
    }
