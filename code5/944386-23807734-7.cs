       Public ReadOnly Property TValue As Object
          Get
             Dim R As Object = Nothing
             Select Case _type
                 Case GenericTypes.TInt32
                    R = Int32.Parse(_value) 
                Case GenericTypes.TFont
                    R = TypeDescriptor.GetConverter(GetType(System.Drawing.Font)) _
                              .ConvertFromInvariantString(_value)
                Case etc
             End Select
          
             Return R
          End Get
        End Property
