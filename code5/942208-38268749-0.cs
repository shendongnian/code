    [CgsAddInMacro]
            public void Add()
            {
                string controlAssembly = @"C:\VSTS\ScratchProjects\CoreDrawPoC\CoreDrawPoC\bin\Debug\CoreDrawPoC.dll";
                var mySlider = app.FrameWork.CommandBars["Standard"].Controls.AddCustomControl("CoreDrawPoC.MySlider", controlAssembly);
                mySlider.Caption = "Border Sizing Slider Caption";
                mySlider.ToolTipText = "Border Sizing Slider Tooltip";
    
                var myButton = app.FrameWork.CommandBars["Standard"].Controls.AddCustomControl("CoreDrawPoC.ButtonSample", controlAssembly);
                myButton.Caption = "Rectanlge Selector";
                mySlider.ToolTipText = "Rectanlge Selector Tooltip";
                
            }
