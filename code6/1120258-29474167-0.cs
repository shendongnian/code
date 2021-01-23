    private void SaveColumnSort(GridViewColumn gridViewColumn, string type)
      {
         var sortDirection = string.Empty;
         switch (gridViewColumn.SortingState)
         {
            case SortingState.None:
               sortDirection = "ASC";
               break;
            case SortingState.Ascending:
               sortDirection = "DESC";
               break;
            default:
               sortDirection = "ASC";
               break;
         }
         var sort = string.Format("{0};{1}", gridViewColumn.Header, sortDirection);
         switch (type)
         {
            case "Claims":
               PopulationOverlayInstance.Settings.RegOverlayClaimsColumnSort = sort;
               break;
            case "Charges":
               PopulationOverlayInstance.Settings.RegOverlayChargesColumnSort = sort;
               break;
         }
         
         PopulationOverlayInstance.Settings.Save();
      }
