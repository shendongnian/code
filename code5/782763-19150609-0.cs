        /// <summary>
        /// prompt for dollar input
        /// <para>» inputs and return are 'decimal?' type</para>
        /// </summary>
        public decimal? DisplayPromptForMoney(string promptText, decimal? minValue = null, decimal? maxValue = null)   
        {
            PromptMoney pmptMoney = new PromptMoney(promptText, minValue, maxValue);
            DisplayPromptForValue(pmptMoney);
            return pmptMoney.ResultValue;
        }
        /// <summary>
        /// prompt for plain number input
        /// <para>» inputs and return are 'int?' type</para>
        /// </summary>
        public int? DisplayPromptForNumber(string promptText, int? minValue = null, int? maxValue = null)        
        {
            PromptNumber prmptNumber = new PromptNumber(promptText, minValue, maxValue);
            DisplayPromptForValue(prmptNumber);
            return prmptNumber.ResultValue;
        }
        /// <summary>
        /// common logic generic wrapper:  
        /// <para>'DisplayPromptForValue()' for 'InternalShowPrompt()</para>
        /// <para>common input logic for:</para>
        /// <para>+ plain number :GenPromptBase«int» ..._OPTION_NUMBER)</para>
        /// <para>+ amount       :GenPromptBase«decimal» ..._OPTION_MONEY)</para>
        /// </summary>
        public void DisplayPromptForValue<T>(GenPromptBase<T> genPmpt) where T : struct, IComparable
        {
            var parameters = MakeParameters(genPmpt.PromptText, false);
            parameters[Constants.FORMAT_TYPE] = genPmpt.InputValueType;
            bool ok;
            do
            {
                string result;
                ok = MakePrompt(parameters, out result);
                if (ok)
                {
                    genPmpt.ParseInput(result);
                    if (genPmpt.TooLow)
                    {
                        MsgPopUp(string.Format("must be at least:{0}", genPmpt.MinValFmt));
                        continue;
                    }
                    if (genPmpt.TooHigh)
                    {
                        MsgPopUp(string.Format("can not be over:{0}", genPmpt.MaxValFmt));
                        continue;
                    }
                    // input meets requirements, end input query loop
                    break;
                }
            }
            while (!ok);
        }
        /// <summary>
        /// abstracted Generic Prompt Base
        /// </summary>
        public abstract class GenPromptBase<T> where T : struct, IComparable
        {
            public GenPromptBase(string inputValueType, string promptText, T? minValue = null, T? maxValue = null)
            {
                InputValueType = inputValueType;
                PromptText = promptText;
                MinValue = minValue;
                MaxValue = maxValue;
                ResultValue = null;
            }
            public abstract void ParseInput(string result);
            public string InputValueType;
            public string PromptText;
            public T? MinValue;     // inputted value
            public T? MaxValue;     // inputted value
            public T? ResultValue;  // returned value 
            public bool TooLow
            {
                get //  ComapareTo     0:  obj == MinValue            obj == ResultValue
                {   //                >0:  obj then MinValue
                    //                <0:  MinValue then obj
                    return this.MinValue.HasValue && (this.MinValue.Value.CompareTo(this.ResultValue.Value) > 0);
                }
            }
            public bool TooHigh
            {
                get //  ComapareTo     0:  obj == MaxValue            obj == ResultValue
                {   //                >0:  obj then MaxValue
                    //                <0:  MaxValue then obj
                    return this.MaxValue.HasValue && (this.MaxValue.Value.CompareTo(this.ResultValue.Value) < 0);
                }
            }
            public string MinValFmt
            {
                get { return string.Format("{0}", this.MinValue.Value); }
            }
            public string MaxValFmt
            {
                get { return string.Format("{0}", this.MaxValue.Value); }
            }
        }
        /// <summary>
        /// Derived Generic 'Money' class of 'GenPromptBase'
        /// <para>Money based logic uses 'decimal?' type.</para>
        /// <para>This derived class insulates (makes internal to itself) all</para>
        /// <para>'Money' and 'decimal?' specific logic.</para>
        /// </summary>
        public class PromptMoney : GenPromptBase<decimal>
        {
            public PromptMoney(string promptText,
                                decimal? minValue = null,
                                decimal? maxValue = null)
                : base(Constants.U_GOI_FORMAT_OPTION_MONEY, promptText, minValue, maxValue)
            { }
            public override void ParseInput(string result)
            {
                ResultValue = decimal.Parse(result);
            }
        }
        /// <summary>
        /// Derived Generic 'Number' class of 'GenPromptBase'
        /// <para>Value, as plain number, based logic uses 'int?' type.</para>
        /// <para>This derived class insulates (makes internal to itself) all</para>
        /// <para>'Number' and 'int?' specific logic.</para>
        /// </summary>
        public class PromptNumber : GenPromptBase<int>
        {
            public PromptNumber(string promptText,
                                 int? minValue = null,
                                 int? maxValue = null)
                : base(Constants.U_GOI_FORMAT_OPTION_NUMBER, promptText, minValue, maxValue)
            { }
            public override void ParseInput(string result)
            {
                ResultValue = int.Parse(result);
            }
        }
