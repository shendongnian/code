    public async Task<List<Device>> GetAllAsync() {
        var result = new List<Device>();
        const string sql = "<SQL>";
        using (var connection = await CreateConnection())
        using (var multi = connection.QueryMultiple(sql, parms)) {
            result = multi.Read<Device>().ToList();
            var sensors = multi.Read<Sensors>().ToList();
            result.ForEach(device => device.Sensors =
                sensors.Where(s => s.DeviceId = device.Id).ToList());
        }
        return result;
    }
