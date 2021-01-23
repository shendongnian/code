     public static bool IsFieldEditableInSP2010(SPField spField)
            {
                SPList spList = spField.ParentList;
    
                SPFieldLookup fldLookup = spField as SPFieldLookup;
                bool bCountRelated = fldLookup != null && fldLookup.CountRelated;
                bool bMcolLookup = fldLookup != null && fldLookup.IsDependentLookup &&
                                                fldLookup.LookupList != "Docs";
    
                SPFieldType t = spField.Type;
                if (t == SPFieldType.Computed ||
                    t == SPFieldType.File ||
                    t == SPFieldType.Recurrence ||
                    t == SPFieldType.CrossProjectLink ||
                    t == SPFieldType.AllDayEvent)
                {
                    return false;
                }
    
                if (!spField.Reorderable &&
                    !bCountRelated &&
                    !(spField.ReadOnlyField && spField.Type == SPFieldType.User) &&
                    !(bMcolLookup && !spField.Hidden) &&
                    !spList.HasExternalDataSource)
                {
                    return false;
                }
                
    
                if ((spField.ReadOnlyField && !bCountRelated && !bMcolLookup) ||
                    spList.HasExternalDataSource)
                {
    		if(spField.Type == SPFieldType.Calculated || spField.Type == SPFieldType.User)
    			return true;
    			
                }
                else
                    return true;
    
                return false;
            } 
