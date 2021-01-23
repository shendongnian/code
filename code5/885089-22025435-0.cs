            private WpfText _LoadNumberText = null;
            public WpfText LoadNumberText
            {
                get
                {
                    if ((this._LoadNumberText == null))
                    {
                        this._LoadNumberText = new WpfText(this.UIGradeStarpoweredbyExWindow.UIItemCustom2.UIItemCustom1);
                        #region Search Criteria
                        this._LoadNumberText.SearchProperties[WpfText.PropertyNames.AutomationId] = "DocNumber";
                        this._LoadNumberText.WindowTitles.Contains("Window Title");
                        #endregion
                    }
                    return this._LoadNumberText;
                }
