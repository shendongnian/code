    protected void CreateRdpActiveX()
    {
        try
        {
            string clsid=GetRdpActiveXClsIdByOSVersion();
            Type type = Type.GetTypeFromCLSID(clsid, true);
            this.axRdp = new AxHost (type.GUID.ToString());
            ((ISupportInitialize)(axRdp)).BeginInit();
            SuspendLayout();
            this.panel1.Controls.Add(axRdp);     
            ((ISupportInitialize)(axRdp)).EndInit();
            ResumeLayout(false);
            var msRdpClient8 = axRdp.GetOcx() as IMsRdpClient8;
            if(msRdpClient8!=null)
            {
                 var advancedSettings9 =msRdpClient8.AdvancedSettings9 as IMsRdpClientAdvancedSettings8;
                 if(advancedSettings9!=null) 
                     advancedSettings9.BandwidthDetection=true;
    
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
