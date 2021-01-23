        public void ThisAddIn_OnUpdateRibbon(object a1, StateChangeArgs e)
        {
            refreshButtonState = e.GetInfo();
            ribbon.InvalidateControl("btnRefreshQuery");
        }
