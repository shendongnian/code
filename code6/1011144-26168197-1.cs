        using System;
        using ESRI.ArcGIS.EsriSystem;
        using ESRI.ArcGIS.Geoprocessing;
        
        public void getfilenameTool()
        {
        object sev = null;
        // Initialize the geoprocessor.
        IGeoProcessor2 gp = new GeoProcessorClass();
        
        // Add your toolbox, you will have to alter the path.
        gp.AddToolbox(@"C:\temp\MyTools.tbx");
        // Execute the tool by name.
        gp.Execute("getfile", null, null);
        string messages = gp.GetMessages(ref sev);
        }
