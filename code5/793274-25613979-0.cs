    using Vestris.VMWareLib;
    
    private void powerOnVm(string vmName)
    {
        using (VMWareVirtualHost esxServer = new VMWareVirtualHost())
        {
            esxServer.ConnectToVMWareVIServer("yourHost", "yourUser", "yourPassword");
            using (VMWareVirtualMachine virtualMachine = esxServer.RegisteredVirtualMachines.FirstOrDefault(vm => vm.Name == vmName))
            {
                if (virtualMachine != null && !virtualMachine.IsRunning)
                    virtualMachine.PowerOn();
            }
        }
    }
