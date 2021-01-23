    public abstract class PlcValueContainerBase
    {
        ...
        
        internal abstract void ApplyReadResult(IntermediateReadResult intermediateReadResult);
        
        internal abstract void ContributeWrite(IntermediateWriteData intermediateWriteData);
        
        ...
    }
    public class PlcValueContainer<TValue> : PlcValueContainerBase
    {
        public TValue Value { get; set; }
        
        internal override void ApplyReadResult(IntermediateReadResult intermediateReadResult)
        {
            intermediateReadResult.Apply<TValue>(value => Value = value);
        }
        
        internal override void ContributeWrite(IntermediateWriteData intermediateWriteData)
        {
            intermediateWriteData.Append(Address, Value, Length);
        }
    }
    public abstract class IntermediateReadResult
    {
        protected internal abstract void Apply<TValue>(Action<TValue> valueAction);
    }
    class MitsubishiIntermediateReadResult : IntermediateReadResult
    {
        private readonly short[] data;
        public MitsubishiIntermediateReadResult(short[] data)
        {
            this.data = data;
        }
        protected override void Apply<TValue>(Action<TValue> valueAction)
        {
            valueAction(MitsubishiDataConverter.ConvertFromPlc<TValue>(data));
        }
    }
