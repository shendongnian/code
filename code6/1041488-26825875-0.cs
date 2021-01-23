    using (var transaction = session.BeginTransaction())
    {
        device.Ips.Add(ip);
        // new line
        ip.Device == device;
        session.Save(device);
        transaction.Commit();
    }
