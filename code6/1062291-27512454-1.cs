      private bool isSubSite()
    {
        using (SpWeb currWeb = SpContext.Current.Web){
            using (SPWeb rootWeb = currWeb.Site.RootWeb){
                if (currWeb.ID != rootWeb.ID)
                    return true;
                return false;
            }
        }
    }
