    public static class Constants
    {
        public const string U_GOI_FORMAT_OPTION_MONEY = "";
        public const string U_GOI_FORMAT_OPTION_NUMBER = "";
    }
    /// <summary>
    /// abstracted Generic Prompt Base
    /// </summary>
    public abstract class GenPromptBase
    {
        public string InputValueType { get; set; }
        public abstract bool TooLow { get; }
        public abstract void ParseInput(string result);
    }
    /// <summary>
    /// Derived Generic 'Money' class of 'GenPromptBase'
    /// </summary>
    public class GenPromptMoney : GenPromptBase
    {
        PromptMoney _prmpt;
        public GenPromptMoney(PromptMoney prmptParms)
        {
            _prmpt = prmptParms;
            InputValueType = _prmpt.InputValueType;
        }
        public override void ParseInput(string result)
        {
            _prmpt.ResultValue = decimal.Parse(result);
        }
        public override bool TooLow
        {
            get
            {
                return _prmpt.TooLow;
            }
        }
    }
    /// <summary>
    /// Derived Generic 'Value' class of 'GenPromptBase'
    /// </summary>
    public class GenPromptValue : GenPromptBase
    {
        PromptValue _prmpt;
        public GenPromptValue(PromptValue prmptParms)
        {
            _prmpt = prmptParms;
            InputValueType = _prmpt.InputValueType;
        }
        public override void ParseInput(string result)
        {
            _prmpt.ResultValue = int.Parse(result);
        }
        public override bool TooLow
        {
            get
            {
                return _prmpt.TooLow;
            }
        }
    }
    /// <summary>
    /// Generic Prompt Class 
    /// </summary>
    public class GenPrompt<Z> where Z: struct, IComparable
    {
        public string InputValueType { get; set; }
        public Z? MinValue;
        public Z? ResultValue;
        public Z? MaxValue;
        public bool TooLow
        {
            get
            {
                return this.MinValue.HasValue && (this.MinValue.Value.CompareTo(this.ResultValue.Value) >= 0);
            }
        }
    }
    /// <summary>
    /// Derived 'Money' class of 'GenPrompt« decimal? »'
    /// </summary>
    public class PromptMoney : GenPrompt<decimal>
    {
        public PromptMoney(
                            decimal? minValue = null,
                            decimal? maxValue = null,
                            string inputValueType = Constants.U_GOI_FORMAT_OPTION_MONEY)
        {
            InputValueType = inputValueType;
            MinValue = minValue;
            MaxValue = maxValue;
            ResultValue = null;
        }
    }
    /// <summary>
    /// Derived 'Value' class of 'GenPrompt« int? »'
    /// </summary>
    public class PromptValue : GenPrompt<int>
    {
        public PromptValue(
                int? minValue = null,
                int? maxValue = null,
                string inputValueType = Constants.U_GOI_FORMAT_OPTION_NUMBER)
        {
            InputValueType = inputValueType;
            MinValue = minValue;
            MaxValue = maxValue;
            ResultValue = null;
        }
    }
