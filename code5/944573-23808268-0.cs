    [RoutePrefix("api/device")]
    public class DeviceController : ApiController
    {
    List<Device> machines = new List<Device>();
    [HttpGet]
    [Route("Machines")]
    public IEnumerable<Device> GetAllMachines()
    {
        //do something
        return machines;
    }
    [HttpGet]
    [Route("Machines/{id:int}")]
    public IEnumerable<Device> GetMachineByID(int id)
    {
        //do something
        return machines;
    }
    [HttpGet]
    [Route("Machines/{key}")]
    public IEnumerable<Device> GetMachinesByKey(string key)
    {
        //do something
        return machines;
    }
