    var finalList=finalList
        .Select(fl=>new State
        {
            fl.IdState,
            fl.NameState,
            cityList=cityList.Where(cl=>cl.IdState==fl.IdState).Select(cl=>
                new City
                {
                    cl.IdCity,
                    cl.NameCity,
                    cl.IdState,
                    companyList=companyList.Where(comp=>
                        comp.IdState==cl.IdState && comp.IdCity==cl.IdCity)
                }
        });
