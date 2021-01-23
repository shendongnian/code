    //http://stackoverflow.com/questions/22093843
    public interface ITheoryDatum
    {
        object[] ToParameterArray();
    }
    public abstract class TheoryDatum : ITheoryDatum
    {
        public abstract object[] ToParameterArray();
        public static ITheoryDatum Factory<TSystemUnderTest, TExpectedOutput>(TSystemUnderTest sut, TExpectedOutput expectedOutput, string description)
        {
            var datum= new TheoryDatum<TSystemUnderTest, TExpectedOutput>();
            datum.SystemUnderTest = sut;
            datum.Description = description;
            datum.ExpectedOutput = expectedOutput;
            return datum;
        }
    }
    public class TheoryDatum<TSystemUnderTest, TExecptedOutput> : TheoryDatum
    {
        public TSystemUnderTest SystemUnderTest { get; set; }
        public string Description { get; set; }
        public TExpectedOutput ExpectedOutput { get; set; }
        public override object[] ToParameterArray()
        {
            var output = new object[3];
            output[0] = SystemUnderTest;
            output[1] = ExpectedOutput;
            output[2] = Description;
            return output;
        }
    }
