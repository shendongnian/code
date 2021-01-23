    ITimeDisplayEvents_DisplayTimeChangedEventHandler DTC_EH;
        private void enableTimeDisplayEventHandler(bool enable = true)
            {
    
                IMxDocument pMxDoc = ArcMap.Document;
                IMap pMap = pMxDoc.FocusMap;
                IActiveView pActiveView = pMap as IActiveView;
                IScreenDisplay pScreenDisplay = pActiveView.ScreenDisplay;
                ITimeDisplay pTimeDisplay = pScreenDisplay as ITimeDisplay;
    
        DTC_EH = new ITimeDisplayEvents_DisplayTimeChangedEventHandler(this.OnDisplayTimeChangedEventHandler);
                            ((ITimeDisplayEvents_Event)pTimeDisplay).DisplayTimeChanged += DTC_EH;
    }
    private void OnDisplayTimeChangedEventHandler(IDisplay d, object oldvalue, object newvalue)
    {
                IMxDocument pMxDoc = ArcMap.Document;
                IMap pMap = pMxDoc.FocusMap;
                IActiveView pActiveView = pMap as IActiveView;
                pActiveView.Refresh();
    }
