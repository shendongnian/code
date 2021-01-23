    //Create Drive Mapping List
    var blockDeviceMappingList = new List<BlockDeviceMapping>();
    
    //Create Mappings
    var blockDeviceMapping = new BlockDeviceMapping();
    var blockDeviceMapping2 = new BlockDeviceMapping();
    
    //Specif a mount point of the drive you want (root)
    blockDeviceMapping.DeviceName = "/dev/sda1";
    var ebsBlockDevice = new EbsBlockDevice();
    //Set something other than null constructor or u get an error about EBS not set. Likely has to do with how they build the request to send to the server
    ebsBlockDevice.VolumeType = VolumeType.Standard; 
    blockDeviceMapping.Ebs = ebsBlockDevice;
    
    //Specif a mount point of the unwanted drive and set EBS to null and NoDevice
    blockDeviceMapping2.DeviceName = "/dev/sdf";
    blockDeviceMapping2.Ebs = null;
    blockDeviceMapping2.NoDevice = string.Empty;
    
    //Add the mappings to the list
    blockDeviceMappingList.Add(blockDeviceMapping);
    blockDeviceMappingList.Add(blockDeviceMapping2);
    
    //Setup Request
    createImageRequest.BlockDeviceMappings = blockDeviceMappingList;
=)
