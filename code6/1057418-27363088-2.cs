        public void getData(vCenter v)
        {
            VimClient client = connectToVC(v);
            NameValueCollection vmFilter = new NameValueCollection();
            vmFilter.Add("name", hostName);
            VirtualMachine vm = (VirtualMachine)client.FindEntityView(typeof(VirtualMachine), null, vmFilter, null);
            Console.WriteLine("cpu", getVMSpec(vm, "vCPU"));
            Console.WriteLine("mem", getVMSpec(vm, "Mem"));
        }
