    ///BEFORE setting DB connection 
    ParameterFieldDefinitions parmFields = cr.DataDefinition.ParameterFields;
    foreach (ParameterFieldDefinition def in parmFields)
    {
       if (!def.IsLinked() )
         {
    
         switch (def.ValueType)
         {
               case CrystalDecisions.Shared.FieldValueType.StringField:
                  cr.SetParameterValue(def.Name, "", def.ReportName);
                  break;
             
               case CrystalDecisions.Shared.FieldValueType.NumberField:
                  cr.SetParameterValue(def.Name, 0, def.ReportName);
                  break;
      
               default:
                  cr.SetParameterValue(def.Name, null, def.ReportName);
                  break;
         }
                                
        }
    ///Now set DB connections 
     ...
    
    ///Now set all parameters which INDEED HAVE be set ...
     ...
