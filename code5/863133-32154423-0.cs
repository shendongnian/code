    size = 1;
    msg = "D1"
    object[] objs = new object[] { size, msg };
    
    ObjectPacker packer = new ObjectPacker();
    packedmsg = packer.Pack<object[]>(objs);
