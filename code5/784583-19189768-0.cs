     if (!result.Exists("TestResultDestination", 0))
     {
           //once we have added this element do not add it again, it will overwrite the other array elements
           var newPropertyObject = sequenceContext.Engine.NewPropertyObject(PropertyValueTypes.PropValType_Container, true, string.Empty, PropertyOptions.PropOption_InsertIfMissing);
           //for my example I only need 5 elements, set the dimension of the array                                        
           newPropertyObject.SetNumElements(5, 0);
           result.SetPropertyObject("TestResultDestination", PropertyOptions.PropOption_InsertIfMissing, newPropertyObject);
           result.SetFlags(newKey, PropertyOptions.PropOption_NoOptions, PropertyFlags.PropFlags_IncludeInReport | PropertyFlags.PropFlags_IsMeasurementValue);
      }
