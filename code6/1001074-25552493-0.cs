    var args = new VirtualMachineCreateDeploymentParameters
    {
        Name = vmname,
        Roles = new List<Role>
        {  
            new Role
            {
                RoleType = "PersistentVMRole",
                RoleName = vmname,
                RoleSize = "ExtraSmall",
                ConfigurationSets = new List<ConfigurationSet>(),
                VMImageName = "captured-vm-image-xx",
                ProvisionGuestAgent = true,
            },
        },
        DeploymentSlot = DeploymentSlot.Production,
        Label = vmname,
    };
    
    await client.VirtualMachines.CreateDeploymentAsync(clusterName, args);
