    public class ServiceWrapper
    {
        private IList<string> list1;
        private IList<string> list2;
        private IList<string> list3;
        private IList<string> list4;
        private readonly Service1 service;
        public ServiceWrapper(Service1 service)
        {
            this.service = service;
        }
        public SomeClass GetSomething()
        {
            list1 = service.Get1();
            list2 = service.Get2();
            foreach (var item2 in list2)
            {
                PopulateMore(item2);
            }
            return result;//Return some computed result
        }
        private void PopulateMore(string item2)
        {
            list3 = service.Get3(item2);
            foreach (var item3 in list3)
            {
                PopulateEvenMore(item3);
            }
        }
        private void PopulateEvenMore(string item3)
        {
            list4 = service.Get4(item3);
            foreach (var item4 in list4)
            {
                //And so on
            }
        }
    }
