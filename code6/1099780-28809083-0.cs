    static class Program
        {
            Static DataFromADVM _vm
            static void Main(string[] args)
            {
                // ...
                _vm = InsertData.Insert();
                GetData.Read(_vm);
                // ...
            }
        }
    public class InsertData
    {
        DataFromADVM _DataVm = new DataFromADVM();
        public static DataFromADVM Insert()
        {
            DataFromAD dataFromAd = new DataFromAD();
            dataFromAd.Id = 0;
            dataFromAd.Key = "name";
            dataFromAd.Value = "Peeter";
            _DataVm.AddDataFromAD(dataFromAd);
        }
        return _DataVm;
    }
    public class GetData
        {
           public void Read()
           {
              var checkList = _vm.ADData.Count;
                return checkList;
           }
        }
