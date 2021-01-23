        /// <summary>
        /// Converts the native class UPnP device to a generic UPnP device.
        /// </summary>
        /// <param name="nativeDevice">The native device.</param>
        /// <returns>
        /// The converted <see cref="UpnpDevice"/>
        /// </returns>
        private UpnpDevice ConvertNativeUPnPDeviceToGenericUpnpDevice(IUPnPDevice nativeDevice)
        {
            UpnpDevice genericDevice = null;
            if (nativeDevice != null)
            {
                IList<UpnpDevice> genericDeviceChildren = new List<UpnpDevice>();
                IList<String> genericDeviceServices = new List<String>();
                // Converting recursively the children of the native device
                if (nativeDevice.HasChildren)
                {
                    foreach (IUPnPDevice nativeDeviceChild in nativeDevice.Children)
                    {
                        genericDeviceChildren.Add(ConvertNativeUPnPDeviceToGenericUpnpDevice(nativeDeviceChild));
                    }
                }
                try
                {
                    // Converting the services, it may break on some modems like old Orange Liveboxes thus the try/catch
                    foreach (IUPnPService nativeDeviceService in nativeDevice.Services)
                    {
                        genericDeviceServices.Add(nativeDeviceService.ServiceTypeIdentifier);
                    }
                }
                catch (Exception exception)
                {
                    string msg = this.GetType().Name + " - Method ConvertNativeUPnPDeviceToGenericUpnpDevice - Reading the services threw an exception: " + exception.Message;
                    m_Logger.Error(msg);
                }
                genericDevice = new UpnpDevice(nativeDevice.UniqueDeviceName,
                nativeDevice.Description,
                nativeDevice.FriendlyName,
                nativeDevice.HasChildren,
                nativeDevice.IsRootDevice,
                nativeDevice.ManufacturerName,
                nativeDevice.ManufacturerURL,
                nativeDevice.ModelName,
                nativeDevice.ModelNumber,
                nativeDevice.ModelURL,
                nativeDevice.PresentationURL,
                nativeDevice.SerialNumber,
                nativeDevice.Type,
                nativeDevice.UPC,
                genericDeviceServices,
                genericDeviceChildren);
            }
            return genericDevice;
        }
