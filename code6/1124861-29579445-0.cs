        try
        {
            VMWareVirtualHost host = new VMWareVirtualHost();
            host.ConnectToVMWareVIServer("172.16.1.72", "root","123456");
            //host.Disconnect();
            IVMWareVirtualMachine machine = new VMWareVirtualMachine();
            machine = host.Open("[datastore1] Kerio contarol/Kerio contarol.vmx");
            machine.PowerOff();
            if (machine.IsRunning == true)
            {
                MessageBox.Show("Machine is running");
            }
            else
            {
                MessageBox.Show("Machine is not rinning");
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
