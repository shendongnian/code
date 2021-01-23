    foreach (ParameterFieldDefinition def in doc.DataDefinition.ParameterFields)
            {
                if (!def.IsLinked())
                {
                    switch (def.ValueType)
                    {
                        case CrystalDecisions.Shared.FieldValueType.StringField:
                            doc.SetParameterValue(def.Name, "");
                            break;
                        case CrystalDecisions.Shared.FieldValueType.NumberField:
                            doc.SetParameterValue(def.Name, 0);
                            break;
                        default:
                            doc.SetParameterValue(def.Name, null);
                            break;
                    }
                }
            }
            doc.SetDataSource(table);
    // Set parameters as I wanted from the beginning
