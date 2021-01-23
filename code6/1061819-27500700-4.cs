    public interface ITest
    {
        DateTime DateNow { get; set; }
        double Calc();
    }
    public class Test : ITest
    {
        public virtual DateTime DateNow // ** NB : Virtual
        { // ....
