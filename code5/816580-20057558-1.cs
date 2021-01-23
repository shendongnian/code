    result = from mID in em.Medicals
          join ms in em.MedicalServices on mID.MsMedicalFK 
          equals ms.ServiceID
          join c in em.Cities on mID.CityFK equals c.CityID
          join reg in em.Regions on c.RegionFK equals 
          reg.RegionID
          where ms.ServiceID == SelectedMedicalService 
          &&
          c.CityID == SelectedCity
          select new Classes.MedicalCityRegionView()
                      { V_Medical = mID,
                        V_City = c,
                        V_Region = reg,
                        V_MedicalService = ms};     
