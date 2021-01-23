    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VMware.Vim;
    
    namespace vSphereCli
    {
        class Program
        {
            static void Main(string[] args)
            {
                VMware.Vim.VimClientImpl c = new VimClientImpl();
                ServiceContent sc = c.Connect("https://HOSTNAME/sdk");
                UserSession us = c.Login("admin@vsphere.local", "password");
                IList<VMware.Vim.EntityViewBase> vms = c.FindEntityViews(typeof(VMware.Vim.VirtualMachine), null, null, null);
                foreach (VMware.Vim.EntityViewBase tmp in vms)
                {
                    VMware.Vim.VirtualMachine vm = (VMware.Vim.VirtualMachine)tmp;
                    Console.WriteLine((bool)(vm.Guest.GuestState.Equals("running") ? true : false));
                    Console.WriteLine(vm.Guest.HostName != null ? (string)vm.Guest.HostName : "");
                    Console.WriteLine("");
                }
                Console.ReadLine();
            }
        }
    }
