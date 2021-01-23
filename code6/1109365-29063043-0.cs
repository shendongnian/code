            public DetailsData GetDetailsData(Type t) 
            {
                dynamic typVal = new ExpandoObject();
    
                if(t == typeof(CityDetails))
                {
                    typVal = new CityDetails();
                }
                // add other types
                
                return (DetailsData)PopulateDetailsData(typVal);
            }
          
            public DetailsData PopulateDetailsData(CityDetails cd)
            {
                cd.Planet = new CityDetails().Planet;
                return cd;
            }
    
            // Add other type related methods with same 
            // signature with input parameter differentiated by types
            // for example
            public DetailsData PopulateDetailsData(TownDetails td)
            {
                td.Income = new TownDetails().Income;
                return td;
            }
