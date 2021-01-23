    using System.Web.Http;
    using AysncTask = System.Threading.Tasks.Task;
    public class myController : ApiControllerBase
    {
            [HttpPut]
            [Route("api/cleardata/{id}/{requestId}/")]
            public async AysncTask ClearData(Guid id, Guid requestId)
            {
                try
                {
                    await AysncTask.Run(() => DoClearData(id, requestId));
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception in myController.ClearData", ex);
                }
            }
    }
