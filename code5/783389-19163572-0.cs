    gvShipments.UseAccessibleHeader = true;
    gvShipments.HeaderRow.TableSection = TableRowSection.TableHeader;
    if (gvShipments.TopPagerRow != null)
    {
         gvShipments.TopPagerRow.TableSection = TableRowSection.TableHeader;
    }
    if (gvShipments.BottomPagerRow != null)
    {
         gvShipments.BottomPagerRow.TableSection = TableRowSection.TableFooter;
    }
