    public class ConstantHelper : IConstantHelper
    {
        public string ConstantForLog
        {
            get
            {
                return ConfigSection.GetConfigSection().ConstantsSettings["ConstantForLog"].Constants;
            }
        }
    }
    public interface IConstantHelper
    {
        string ConstantForLog { get; }
    }
