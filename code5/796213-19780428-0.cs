     LegacyIAccessiblePattern legacyPattern = null;
           try
           {
               legacyPattern = datagrid.GetCurrentPattern(LegacyIAccessiblePattern.Pattern) as LegacyIAccessiblePattern;
           }
           catch (InvalidOperationException ex)
           {
               // It passes!
           }
