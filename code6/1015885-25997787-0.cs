    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Task<Model>
                var sw = Stopwatch.StartNew();
                Console.WriteLine("1: " + sw.Elapsed);
                var taskGetModel = GetModel(22);
                Console.WriteLine("2: " + sw.Elapsed);
                taskGetModel.Wait();
                Console.WriteLine("3: " + sw.Elapsed);
                // Task without TResult
                var taskSaveModel = SaveModel(taskGetModel.Result);
                Console.WriteLine("4: " + sw.Elapsed);
                taskSaveModel.Wait();
                Console.WriteLine("5: " + sw.Elapsed);
            }
            public async static Task<Model> GetModel(int number)
            {
                var baseData = await service.GetBaseData();
                var model = await service.GetModel(baseData, number);
                model.BaseData = baseData;
                return model;
            }
            public static async Task SaveModel(Model model)
            {
                await service.SaveModel(model);
            }
            static Service service = new Service();
            class Service
            {
                public Task SaveModel(Model model)
                {
                    return Task.Delay(1000);
                }
                public async Task<Model> GetModel(object baseData, int number)
                {
                    await Task.Delay(1000);
                    return new Model();
                }
                public async Task<object> GetBaseData()
                {
                    await Task.Delay(1000);
                    return new object();
                }
            }
        }
        public class Model
        {
            public object BaseData { get; set; }
        }
    }
