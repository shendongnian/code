    public interface IKnowWhatProcessorIWant {
        IProcessor CreateProcessor();
    }
    public class ACHData : BaseData, IKnowWhatProcessorIWant {
        public IProcessor CreateProcessor() {
            return new GetACHProcessor(this);
        }
    }
