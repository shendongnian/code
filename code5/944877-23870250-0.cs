        If isSomeCondition Then
            ModelState.Remove("Property1")
            ModelState.Remove("Property2")
        End If
        If ModelState.IsValid() Then
           ...
        End If
