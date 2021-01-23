    var list = objAssessment.tblThreatenedSpeciesSubzone.Rows.ToList(); // <- Linq    
    for (int i = list.Count - 1; i >= 0; --i) {
      Assessment.tblThreatenedSpeciesSubzoneRow ThreatenedSpeciesSubzoneRow = 
        list[i];
    
      if (ThreatenedSpeciesSubzoneRow.VegetationZoneID == VegetationZoneIDToDelete)
        DeleteThreatenedSpeciesSubzone(ref objAssessment, ThreatenedSpeciesSubzoneRow.ThreatenedSpeciesZoneID, UserFullname, ref ErrorMessage);
    }
