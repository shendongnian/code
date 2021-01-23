    namespace ABPMVCTest.Web.Controllers
    {
    [AbpMvcAuthorize]
    public class HomeController : ABPMVCTestControllerBase
    {
        static Random _ran=new Random();
        public ActionResult Index()
        {
            return View();
        }
        public ContentResult GetJsonResult()
        {
            
            var dataList = new List<ChartDataFormat>();
            GetData(dataList, "总收入");
            GetData(dataList, "投币收入");
            GetData(dataList, "扫码充电收入");
            GetData(dataList, "售线收入");
            var dataJsonStr=JsonConvert.SerializeObject(dataList,new JsonSerializerSettings(){ContractResolver = new CamelCasePropertyNamesContractResolver()});
            return Content(dataJsonStr);
        }
        private static List<ChartDataFormat> GetData(List<ChartDataFormat> dataList, string key)
        {
            
            var list = new List<int>();
          
            for (int i = 0; i < 7; i++)
            {
              
                list.Add(_ran.Next(1, 3000));
            }
            dataList.Add(new ChartDataFormat
            {
                Name = key,
                Data = list
            });
            
            return dataList;
        }
    }
    class ChartDataFormat
    {
        public string Name { get; set; }
        public List<int> Data { get; set; }
    }
    }
