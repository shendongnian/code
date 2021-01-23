    interface ILoad {
        List<Measure> ConvertToMeasure();
    }
    class A : ILoad {
        public string PropA { get; set; }
        public List<Measure> ConvertToMeasure()
        {
            throw new NotImplementedException();
        }
    }
    class B : ILoad {
        public string PropB { get; set; }
        public List<Measure> ConvertToMeasure()
        {
            throw new NotImplementedException();
        }
    }
