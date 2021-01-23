    private async Task<VehicleStatus> GetVehicleStatusAsync(string clientVehicleID)
    {
        GetStatusResponse Status = await UseAsync(client => client.GetStatusByClientIdAsync(clientVehicleID));
        return Status.vehicleStatus;
    }
