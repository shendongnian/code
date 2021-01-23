    How to Delete Field in featureclass like(cable,meter or Support structure...etc) the code is given below.
    
    Class1.cs file
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Framework;
    
    
    namespace PATICULAR_FIELD_DELETED
    {
        class Class1
        {
            public static IApplication pApplication = null;
            public static IMxDocument pMxDcoument = null;
            public static IMap pMap = null;
        }
    }
    
    
    PARTICULARFIELDDELETED.cs file
    
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using System.Windows.Forms;
    using ESRI.ArcGIS.esriSystem;
    
        enter code here
    
    namespace PATICULAR_FIELD_DELETED
    {
        /// <summary>
        /// Summary description for PARTICULARFIELDDELETED.
        /// </summary>
        [Guid("cb10e93e-58d9-4c81-9107-2eda417a3770")]
        [ClassInterface(ClassInterfaceType.None)]
        [ProgId("PATICULAR_FIELD_DELETED.PARTICULARFIELDDELETED")]
        public sealed class PARTICULARFIELDDELETED : BaseCommand
        {
            #region COM Registration Function(s)
            [ComRegisterFunction()]
            [ComVisible(false)]
            static void RegisterFunction(Type registerType)
            {
                // Required for ArcGIS Component Category Registrar support
                ArcGISCategoryRegistration(registerType);
    
                //
                // TODO: Add any COM registration code here
                //
            }
            [ComUnregisterFunction()]
            [ComVisible(false)]
            static void UnregisterFunction(Type registerType)
            {
                // Required for ArcGIS Component Category Registrar support
                ArcGISCategoryUnregistration(registerType);
    
                //
                // TODO: Add any COM unregistration code here
                //
            }
            #region ArcGIS Component Category Registrar generated code
            /// <summary>
            /// Required method for ArcGIS Component Category registration -
            /// Do not modify the contents of this method with the code editor.
            /// </summary>
            private static void ArcGISCategoryRegistration(Type registerType)
            {
                string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
                MxCommands.Register(regKey);
    
            }
            /// <summary>
            /// Required method for ArcGIS Component Category unregistration -
            /// Do not modify the contents of this method with the code editor.
            /// </summary>
            private static void ArcGISCategoryUnregistration(Type registerType)
            {
                string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
                MxCommands.Unregister(regKey);
    
            }
    
            #endregion
            #endregion
    
            private IApplication m_application;
            public PARTICULARFIELDDELETED()
            {
                //
                // TODO: Define values for the public properties
                //
                base.m_category = "PARTICULARFIELDDELETED"; //localizable text
                base.m_caption = "PARTICULARFIELDDELETED";  //localizable text
                base.m_message = "PARTICULARFIELDDELETED";  //localizable text 
                base.m_toolTip = "PARTICULARFIELDDELETED";  //localizable text 
                base.m_name = "PARTICULARFIELDDELETED";   //unique id, non-localizable (e.g. "MyCategory_ArcMapCommand")
    
                try
                {
                    //
                    // TODO: change bitmap name if necessary
                    //
                    string bitmapResourceName = "PARTICULARFIELDDELETED.bmp";
                    base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
                }
            }
    
            #region Overridden Class Methods
    
            /// <summary>
            /// Occurs when this command is created
            /// </summary>
            /// <param name="hook">Instance of the application</param>
            public override void OnCreate(object hook)
            {
                if (hook == null)
                    return;
    
                m_application = hook as IApplication;
    
                //Disable if it is not ArcMap
                if (hook is IMxApplication)
                    base.m_enabled = true;
                else
                    base.m_enabled = false;
    
                // TODO:  Add other initialization code
            }
    
            /// <summary>
            /// Occurs when this command is clicked
            /// </summary>
            public override void OnClick()
            {
                // TODO: Add PARTICULARFIELDDELETED.OnClick implementation
                Class1.pApplication = m_application;
                Class1.pMxDcoument = m_application.Document as IMxDocument;
                Class1.pMap = Class1.pMxDcoument.ActivatedView.FocusMap;
                if (Class1.pMap.LayerCount == null)
                {
                    MessageBox.Show("No Layers are Found", "PARTICULARFIELDDELETED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    
                IFeatureLayer pMeterFeatureLayer = ListLayers(Class1.pMxDcoument, "METER");
                if (pMeterFeatureLayer == null)
                {
                    return;
                }
                IFeatureClass featureclass = pMeterFeatureLayer.FeatureClass;
                 
                CreateFieldsCollectionForTable(featureclass, "AssetID");
    
            }
            public IFeatureLayer ListLayers(IMxDocument pMxDocument, string layerName)
            {
                UID puid = new UID();
                puid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
                IEnumLayer penumlayer = pMxDocument.ActiveView.FocusMap.get_Layers(puid, true);
                penumlayer.Reset();
                IFeatureLayer featureLayer = penumlayer.Next() as IFeatureLayer;
                while (featureLayer != null)
                {
                    if (featureLayer.Name.ToUpper() == layerName)
                    {
                        break;
                    }
                    featureLayer = penumlayer.Next() as IFeatureLayer;
                }
                return featureLayer;
    
            }
           
            public void CreateFieldsCollectionForTable(IFeatureClass featureclass, string fieldname)
            {
                // Create a fields collection.
                try
                IFields fields = featureclass.Fields;
                IField field = fields.get_Field(fields.FindField("AssetID"));
                featureclass.DeleteField(field);
                MessageBox.Show("We have deleted field successfully", 
    "ParticularFieldDeleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    
            #endregion
        }
    }
