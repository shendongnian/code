                // Get the service provider on the object
                Microsoft.VisualStudio.Data.ServiceProvider serviceProvider = new Microsoft.VisualStudio.Data.ServiceProvider(this._applicationObject as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
                // Get the shell service
                var vsUIShell = (IVsUIShell)serviceProvider.GetService(typeof(SVsUIShell));
                Guid slotGuid = new Guid(guidString);
                // Find the associated window frame on this toolwindow
                IVsWindowFrame wndFrame;
                vsUIShell.FindToolWindow((uint)__VSFINDTOOLWIN.FTW_fFrameOnly, ref slotGuid, out wndFrame);
                // Set the text on the window tab name
                wndFrame.SetProperty((int)__VSFPROPID.VSFPROPID_Caption, "Upgraded Task List");
