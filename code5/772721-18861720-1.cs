    User user = ...
    using (BinaryWriter writer = ...)
    {
        writer.Write((byte)user.id);
        writer.Write(user.age);
    }
